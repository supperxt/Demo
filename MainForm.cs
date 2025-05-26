using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DemoDocuments
{
    public partial class MainForm: Form
    {
        private readonly System.Windows.Forms.Timer refreshTimer;
        private const int RefreshInterval = 60000;

        public MainForm(string login)
        {
            InitializeComponent();
            labelLogin.Text = login;

            comboBoxSave.Items.AddRange(new object[] { "PDF", "TXT" });
            comboBoxSave.SelectedIndex = 0;
            comboBoxSave.DropDownStyle = ComboBoxStyle.DropDownList;

            refreshTimer = new System.Windows.Forms.Timer
            {
                Interval = RefreshInterval
            };
            refreshTimer.Tick += RefreshAllData;
            refreshTimer.Start();

            RefreshAllData(null, null);
        }

        private void RefreshAllData(object sender, EventArgs e)
        {
            LoadPersonsData();
            LoadProgramsData();
        }

        private void LoadPersonsData()
        {
            try
            {
                var query = @"SELECT 
                        LastName AS ""Фамилия"", 
                        FirstName AS ""Имя"", 
                        MiddleName AS ""Отчество"",
                        TO_CHAR(BirthDate, 'DD.MM.YYYY') AS ""Дата рождения"",
                        PassportSeries || ' ' || PassportNumber AS ""Паспорт"",
                        Address AS ""Адрес"",
                        Email AS ""Email"",
                        '+7' || PhoneNumber AS ""Телефон"",
                        Position AS ""Должность"",
                        Workplace AS ""Место работы""
                    FROM Persons";

                dataGridViewPersons.DataSource = DataBaseHelper.GetDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных клиентов: {ex.Message}");
            }
        }

        private void LoadProgramsData()
        {
            try
            {
                var query = @"SELECT 
                        ProgramName AS ""Программа"",
                        DurationMonths || ' мес.' AS ""Срок обучения"",
                        Qualification AS ""Квалификация"",
                        Cost || ' руб.' AS ""Стоимость""
                    FROM EducationPrograms";

                dataGridViewPrograms.DataSource = DataBaseHelper.GetDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных программ: {ex.Message}");
            }
        }

        private void buttonContract_Click(object sender, EventArgs e)
        {
            // 1. Проверка выбора
            if (dataGridViewPersons.SelectedRows.Count == 0 || dataGridViewPrograms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента и программу обучения!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            DataGridViewRow person = dataGridViewPersons.SelectedRows[0];
            DataGridViewRow program = dataGridViewPrograms.SelectedRows[0];

            
            string templatePath = @"E:\ForTeh\DemoDemo\DemoDocuments\contract_template.txt";

            if (!File.Exists(templatePath))
            {
                MessageBox.Show("Шаблон договора не найден!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string templateText = File.ReadAllText(templatePath, Encoding.UTF8);

                
                var replacements = new Dictionary<string, string>
                {
                    ["{signDate}"] = DateTime.Now.ToString("dd MMMM yyyy", new System.Globalization.CultureInfo("ru-RU")),
                    ["{lastName}"] = person.Cells["Фамилия"].Value?.ToString() ?? "",
                    ["{firstName}"] = person.Cells["Имя"].Value?.ToString() ?? "",
                    ["{middleName}"] = person.Cells["Отчество"].Value?.ToString() ?? "",
                    ["{birthDate}"] = person.Cells["Дата рождения"].Value?.ToString() ?? "",
                    ["{address}"] = person.Cells["Адрес"].Value?.ToString() ?? "",
                    ["{passport}"] = person.Cells["Паспорт"].Value?.ToString() ?? "",
                    ["{phone}"] = person.Cells["Телефон"].Value?.ToString() ?? "",
                    ["{program}"] = program.Cells["Программа"].Value?.ToString() ?? ""
                };


                // 5. Заменяем плейсхолдеры в шаблоне
                foreach (var replacement in replacements)
                {
                    templateText = templateText.Replace(replacement.Key, replacement.Value);
                }

                // 6. Показываем диалог сохранения
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    string defaultFileName = $"Договор_{replacements["{lastName}"]}_{DateTime.Now:ddMMyyyy}";

                    switch (comboBoxSave.SelectedItem.ToString())
                    {
                        case "PDF":
                            saveDialog.Filter = "PDF файлы (*.pdf)|*.pdf";
                            saveDialog.FileName = defaultFileName + ".pdf";
                            break;

                        case "TXT":
                            saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                            saveDialog.FileName = defaultFileName + ".txt";
                            break;
                    }

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // 6. Сохранение в выбранном формате
                        switch (comboBoxSave.SelectedItem.ToString())
                        {
                            case "PDF":
                                SaveAsPdf(saveDialog.FileName, templateText);
                                break;

                            case "TXT":
                                File.WriteAllText(saveDialog.FileName, templateText, Encoding.UTF8);
                                break;
                        }

                        MessageBox.Show("Договор успешно сохранен!", "Успех",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании договора:\n{ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveAsPdf(string filePath, string text)
        {
            using (var document = new Document())
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();

                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                var baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                var font = new Font(baseFont, 12);

                document.Add(new Paragraph(text, font));
            }
        }
    }
}

