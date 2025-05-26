using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDocuments
{
    public partial class LogInForm: Form
    {
        private int failedAttempts = 0;
        private const int MaxAttempts = 3;
        private bool resetMode = false;

        public LogInForm()
        {
            InitializeComponent();
        }

        private bool ValidatePassword(string password)
        {
            return password.Count(char.IsLetter) >= 5 &&
                   password.Count(char.IsDigit) >= 3 &&
                   password.IndexOfAny("@#%)(.<".ToCharArray()) != -1;
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            // Режим сброса пароля: кнопка входа не реагирует
            if (resetMode) return;

            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            var (success, name, role) = DataBaseHelper.CheckLogin(login, password);

            if (success)
            {
                var mainForm = new MainForm(login);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                failedAttempts++;

                // Всегда выводим одно сообщение
                MessageBox.Show("Неправильные данные", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);


                if (failedAttempts >= MaxAttempts)
                {
                    resetMode = true;
                    buttonEditPassword.Visible = true;
                }
            }
        }

        private void buttonEditPassword_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string newPassword = textBoxPassword.Text.Trim();

            // Валидация пароля
            if (!ValidatePassword(newPassword))
            {
                MessageBox.Show("Пароль должен содержать:\n5 букв\n3 цифры\n1 спецсимвол (@#%)(.<)");
                return;
            }

            // Обновление в БД
            if (DataBaseHelper.ResetPassword(login, newPassword))
            {
                MessageBox.Show("Пароль успешно изменён");
                textBoxPassword.Clear(); 
                resetMode = false;
                failedAttempts = 0;
                buttonEditPassword.Visible = false;
            }
            else
            {
                MessageBox.Show("Неправильный логинц");
            }
        }
    }
}
