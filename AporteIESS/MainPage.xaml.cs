namespace AporteIESS;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCalcularClicked(object sender, EventArgs e)
    {
        // 1. Validar que no haya campos vacíos
        if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtApellido.Text) ||
            string.IsNullOrWhiteSpace(txtEdad.Text) ||
            string.IsNullOrWhiteSpace(txtSalario.Text))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
            return;
        }

        // 2. Validar que edad sea un número entero
        if (!int.TryParse(txtEdad.Text, out int edad) || edad <= 0)
        {
            await DisplayAlert("Error", "La edad debe ser un número válido.", "OK");
            return;
        }

        // 3. Validar que salario sea un número (acepta coma o punto)
        string salarioTexto = txtSalario.Text.Replace(',', '.');
        if (!double.TryParse(salarioTexto,
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out double salario) || salario <= 0)
        {
            await DisplayAlert("Error", "El salario debe ser un número válido.", "OK");
            return;
        }

        // 4. Calcular el aporte (9,45%)
        double aporte = salario * 0.0945;

        // 5. Mostrar la alerta
        string mensaje = $"Bienvenido {txtNombre.Text} {txtApellido.Text}\n" +
                         $"Tienes {edad} años\n" +
                         $"Tu aporte mensual es ${aporte:F2}";

        await DisplayAlert("Resultado", mensaje, "OK");
    }
}