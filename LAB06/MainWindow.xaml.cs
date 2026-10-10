using System.Windows;
using Entidades;
using Negocio;

namespace LAB06
{
    public partial class MainWindow : Window
    {
        NPersona nPersona = new NPersona();

        public MainWindow()
        {
            InitializeComponent();
            ListarPersonas();
        }

        private void ListarPersonas()
        {
            dgPersonas.ItemsSource = nPersona.ListarPersonas();
        }

        private void dgPersonas_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgPersonas.SelectedItem is Persona persona)
            {
                txtIdPersona.Text = persona.IdPersona.ToString();
                txtNombres.Text = persona.Nombres;
                txtApellidos.Text = persona.Apellidos;
                txtDni.Text = persona.Dni;
                txtTelefono.Text = persona.Telefono;
            }
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            txtIdPersona.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtDni.Text = "";
            txtTelefono.Text = "";

            dgPersonas.SelectedItem = null;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Persona persona = new Persona();
            persona.Nombres = txtNombres.Text;
            persona.Apellidos = txtApellidos.Text;
            persona.Dni = txtDni.Text;
            persona.Telefono = txtTelefono.Text;

            nPersona.RegistrarPersona(persona);

            MessageBox.Show("Persona registrada correctamente.");

            ListarPersonas();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdPersona.Text == "")
            {
                MessageBox.Show("Selecciona una persona de la lista.");
                return;
            }

            Persona persona = new Persona();
            persona.IdPersona = int.Parse(txtIdPersona.Text);
            persona.Nombres = txtNombres.Text;
            persona.Apellidos = txtApellidos.Text;
            persona.Dni = txtDni.Text;
            persona.Telefono = txtTelefono.Text;

            nPersona.ActualizarPersona(persona);

            MessageBox.Show("Persona actualizada correctamente.");

            ListarPersonas();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdPersona.Text == "")
            {
                MessageBox.Show("Selecciona una persona de la lista.");
                return;
            }

            nPersona.EliminarPersona(int.Parse(txtIdPersona.Text));

            MessageBox.Show("Persona eliminada correctamente.");

            ListarPersonas();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            dgPersonas.ItemsSource = nPersona.ListarPersonasPorNombre(txtBuscar.Text);
        }

        private void btnMostrarTodos_Click(object sender, RoutedEventArgs e)
        {
            txtBuscar.Text = "";
            ListarPersonas();
        }
    }
}