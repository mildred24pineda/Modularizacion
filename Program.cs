using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;

int opcion;

do
{
    Console.Clear();
    Console.WriteLine("Menú de Ejercicios de Modularización: ");
    Console.WriteLine("1. Calculadora Básica");
    Console.WriteLine("2. Validación de Contraseñas");
    Console.WriteLine("3. Verificar Número Primo");
    Console.WriteLine("4. Suma de Números Pares");
    Console.WriteLine("5. Conversión de Temperatura");
    Console.WriteLine("6. Contador de Vocales");
    Console.WriteLine("7. Cálculo de Factorial");
    Console.WriteLine("8. Juego de Adivinanzas");
    Console.WriteLine("9. Paso por Referencia");
    Console.WriteLine("10. Tabla de Multiplicar");
    Console.WriteLine("0. Salir");
    Console.WriteLine("---------------------------");
    Console.WriteLine("Elige una opción:");


    if (int.TryParse(Console.ReadLine(), out opcion))
    {
        switch (opcion)
        {
            case 1:
                CalculadoraBasica();
                break;
            case 2:
                ValidacionDeContraseña();
                break;
            case 3:
                VerificacionDeNumeroPrimo();
                break;
            case 4:
                SumaDeNumerosPares();
                break;
            case 5:
                ConversionDeTemperatura();
                break;
            case 6:
                ContadorDeVocales();
                break;
            case 7:
                CalculodeFactorial();
                break;
            case 8:
                JuegodeAdivinanzas();
                break;
            case 9:
                PasosporReferencia();
                break;
            case 10:
                TabladeMultiplicar();
                break;
            case 0:
                Console.WriteLine("Saliendo...");
                break;
            default:
                Console.WriteLine("La opción que acaba de colocar es inválida.");
                break;
        }


    }
    else
    {
        Console.WriteLine("Ingresa un número que sea válido.");
    }
    Console.WriteLine("\nPresiona una tecla para continuar...");
    Console.ReadKey();
} while (opcion != 0);



static void CalculadoraBasica()
{
    Console.WriteLine("Ingresa el primer número: ");
    if (!double.TryParse(Console.ReadLine(), out double num1))
    {
        Console.WriteLine("El número es inválido.");
        return;
    }
    Console.WriteLine("Ingresa el segundo número: ");
    if (!double.TryParse(Console.ReadLine(), out double num2))
    {
        Console.WriteLine("El número es inválido.");
        return;
    }
    Console.WriteLine("Elige una operación matemática: suma, resta, multiplicación, división");
    string operacion = Console.ReadLine() ?? string.Empty;

    double resultado = operacion switch
    {
        "suma" => num1 + num2,
        "resta" => num1 - num2,
        "multiplicacion"=> num1 * num2,
        "division" => num2 != 0 ? num1 / num2 : double.NaN,
        _ => double.NaN
    };

    Console.WriteLine($"Resultado: {resultado}");
}


static void ValidacionDeContraseña()
{
    string contraseña;
    do
    {
        Console.WriteLine("Ingresa la contraseña: ");
        contraseña = Console.ReadLine() ?? string.Empty;
    } while (contraseña != "proverbios17:17");

    Console.WriteLine("El acceso ha sido concedido.");
}


static void VerificacionDeNumeroPrimo()
{
    Console.WriteLine("Ingrese un número: ");
    if (int.TryParse(Console.ReadLine(), out int num))
    {
        bool esPrimo = EsPrimo(num);
        Console.WriteLine(esPrimo ? "El número es Primo" : "El número no es Primo");
    }
    else
    {
        Console.WriteLine("El Número es Invalido.");
    }
}


static bool EsPrimo(int num)
{
    if (num < 2) return false;
    for (int i = 2; i * i <= num; i++)
    {
        if (num % i == 0) return false;
    }
    return true;
}


static void SumaDeNumerosPares()
{
    int suma = 0, num;
    do
    {
        Console.WriteLine("Ingresa un número (0 para Salir): ");
        if (int.TryParse(Console.ReadLine(), out num) && num % 2 == 0)
        {
            suma += num;
        }
    } while (num != 0);

    Console.WriteLine($"La Suma de Pares es: {suma}");
}


static void ConversionDeTemperatura()
{
    Console.WriteLine("Ingresa la Temperatura: ");
    if (!double.TryParse(Console.ReadLine(), out double temperatura))
    {
        Console.WriteLine("El número es invalido. ");
        return;
    }
    Console.WriteLine("Elige una opcion: Celsius a Fahrenheit o Fahrenheit a Celsius");
    string opcion = Console.ReadLine()?.ToUpper() ?? string.Empty;

    double resultado = opcion switch
    {

        "C" => (temperatura * 9 / 5) + 32,
        "F" => (temperatura - 32) * 9 / 5,
        _ => double.NaN
    };

    Console.WriteLine($"La Temperatura Convertida es: {resultado}");
}


static void ContadorDeVocales()
{
    Console.WriteLine("Ingresa una frase: ");
    string frase = Console.ReadLine()?.ToLower() ?? string.Empty;
    int contador = 0;
    foreach (char c in frase)
    {
        if ("aeiou".Contains(c)) contador++;
    }
    Console.WriteLine($"El número de Vocales es: {contador}");
}


static void CalculodeFactorial()
{
    Console.Write("Ingresa un número: ");
    if (int.TryParse(Console.ReadLine(), out int num))
    {
        long factorial = 1;
        for (int i = 1; i <= num; i++)
            factorial *= i;

        Console.WriteLine($"Factorial de {num}: {factorial}");
    }
    else
    {
        Console.WriteLine("Número inválido.");
    }
}


static void JuegodeAdivinanzas()
{
    Random rand = new Random();
    int numerosecreto = rand.Next(1, 101), intento;
    Console.WriteLine("Adivina el numero secreto (1-100)");

    do
    {
        Console.WriteLine("Ingresa un número: ");
        if (int.TryParse(Console.ReadLine(), out intento))
        {
            if (intento < numerosecreto) Console.WriteLine("Demasiado bajo.");
            else if (intento > numerosecreto) Console.WriteLine("Demasiado alto.");
        }
    } while (intento != numerosecreto);

    Console.WriteLine("¡Adivinaste!");
}


static void PasosporReferencia()
{
    Console.Write("Ingresa el primer número: ");
    if (!int.TryParse(Console.ReadLine(), out int num1))
    {
        Console.WriteLine("Número inválido.");
        return;
    }

    Console.Write("Ingresa el segundo número: ");
    if (!int.TryParse(Console.ReadLine(), out int num2))
    {
        Console.WriteLine("Número inválido.");
        return;
    }

    Intercambiar(ref num1, ref num2);

    Console.WriteLine($"Valores intercambiados: {num1}, {num2}");
}

static void Intercambiar(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}


static void TabladeMultiplicar()
{
    Console.Write("Ingresa un número: ");
    if (int.TryParse(Console.ReadLine(), out int num))
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{num} x {i} = {num * i}");
        }
    }
    else
    {
        Console.WriteLine("Número inválido.");
    }
}






