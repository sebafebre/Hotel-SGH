using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Modelo
{
    public class ValidacionesDAL
    {
        //Crear la funcion AbrirFormulario() para que en los formPantallaPrincipal solo tengan que llamar la funcion
        //y pasarle el tipo de formulario que quieren abrir
        //ejemplo: AbrirFormulario(typeof(frmOcupacion));
        public static void AbrirFormulario(Type tipoFormulario, Form frmMenu)
        {
            Form frm = (Form)Activator.CreateInstance(tipoFormulario);

            if (frmMenu != null)
            {
                frm.TopLevel = false;
                frm.AutoScroll = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;

                Panel panelPantalla = (Panel)frmMenu.Controls["panelPantalla"];
                panelPantalla.Controls.Clear();
                panelPantalla.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                MessageBox.Show("El formulario principal no se ha encontrado.");
            }
        }


        public static void CambiarPanel(Type tipoFormulario, Form frmMenu)
        {
            Form frm = (Form)Activator.CreateInstance(tipoFormulario);

            if (frmMenu != null)
            {
                frm.TopLevel = false;
                frm.AutoScroll = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;

                Panel panelPantalla = (Panel)frmMenu.Controls["panelPedidos"];
                panelPantalla.Controls.Clear();
                panelPantalla.Controls.Add(frm);
                frm.Show();
            }
            else
            {
                MessageBox.Show("El formulario principal no se ha encontrado.");
            }
        }

        public static string EncriparClave(string clave)
        {
            byte[] passBytes = Encoding.Unicode.GetBytes(clave);
            SHA1 sha = SHA1.Create();
            byte[] hash = sha.ComputeHash(passBytes);
            string hashString = Encoding.Unicode.GetString(hash);
            return hashString;
        }


        //limpiar campos (textbox, combobox, etc)
        //public void LimpiarCampos(System.Windows.Forms.Control.ControlCollection controles)
        public void LimpiarCampos(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = "";
                }
                else if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    comboBox.SelectedIndex = -1;
                }
                else if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.SelectedIndex = -1;
                }
                else if (control is DateTimePicker)
                {
                    DateTimePicker dateTimepicker = (DateTimePicker)control;
                    dateTimepicker.Value = DateTime.Now;
                }
                else if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }
                else
                {
                    LimpiarCampos(control.Controls);
                }
            }
        }




        public void BuscarPorDNI(string dni, DataGridView dgvClientes)
        {
            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                // Verificamos si el valor en la columna "DNI" contiene el texto ingresado en el TextBox
                if (row.Cells["DNI"].Value != null && row.Cells["DNI"].Value.ToString().ToLower().Contains(dni))
                {
                    row.Visible = true; // Si hay coincidencia, mostramos la fila
                }
                else
                {
                    row.Visible = false; // Si no hay coincidencia, ocultamos la fila
                }
            }
        }



        public string ObtenerEstadoSeleccionado(Control flowLayoutPanel)
        {
            foreach (Control control in flowLayoutPanel.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    // Devuelve el texto del RadioButton seleccionado como estado.
                    return radioButton.Text;
                }
            }
            // Si no se encontró ningún RadioButton seleccionado, puedes devolver un estado predeterminado o lanzar una excepción.
            return null;
        }




        public static void ValidarTextBoxVacio(string texto, string campo)
        {
            if (string.IsNullOrEmpty(texto))
            {
                throw new Exception("Debe ingresar el " + campo);
            }
        }
        public static void ValidarMail(string mail)
        {
            try
            {
                MailAddress m = new MailAddress(mail);
            }
            catch (FormatException)
            {
                throw new Exception("Formato de mail invalido");
            }
        }
        public static void ValidarContraseña(string clave)
        {
            if (clave.Length < 6)
            {
                throw new Exception("La contraseña debe tener al menos 6 caracteres");
            }
        }
        public static void ValidarDni(string dni)
        {
            if (dni.Length < 7 || dni.Length > 8)
            {
                throw new Exception("El DNI debe tener entre 7 y 8 caracteres");
            }
        }
        public static void ValidarNumero(string numero)
        {
            try
            {
                int num = Convert.ToInt32(numero);
            }
            catch (FormatException)
            {
                throw new Exception("El numero debe ser numerico");
            }
        }
        public static void ValidarTelefono(string telefono)
        {
            if (telefono.Length < 7 || telefono.Length > 11)
            {
                throw new Exception("El telefono debe tener entre 7 y 11 caracteres");
            }
        }
        public static void ValidarFechaNac(DateTime fechaNac)
        {
            if (fechaNac > DateTime.Now)
            {
                throw new Exception("La fecha de nacimiento no puede ser mayor a la fecha actual");
            }
        }
        public static void ValidarFecha(DateTime fecha)
        {
            if (fecha < DateTime.Now)
            {
                throw new Exception("La fecha no puede ser menor a la fecha actual");
            }
        }

        //ValidarEmail
        public static bool ValidarEmail(string mail)
        {
            string expresion;
            expresion = @"\A(\w+\.?\w*\@\w+\.)(com)\Z";
            System.Text.RegularExpressions.Regex automata = new Regex(expresion);
            return automata.IsMatch(mail);
        }

        













        



    }
}

