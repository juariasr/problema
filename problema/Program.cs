try
{
    var lista = new List<float>();
    const string NAMEFILE = "numeros.txt";
    string datos = File.ReadAllText(NAMEFILE);
    var limpios = datos.Split(";");
    foreach(string numberString in limpios)
    {
        float number;
        if (float.TryParse(numberString, out number))
        {
            lista.Add(number);
        }
    }

    if(lista.Count > 0) 
    {
        Console.WriteLine(String.Format("La media es: {0}", lista.Average().ToString("n2")));
        Console.WriteLine(String.Format("La desviacion estandar es: {0}", StandardDesviation(lista).ToString("n2")));
        return;
    }

    Console.WriteLine(String.Format("No hay numeros validos en el archivo"));
}
catch (FileNotFoundException ex)
{
    Console.WriteLine(String.Format("El archivo indicado no existe: StackTrace: {0}", ex));
}


/*****************************************************************/
/* Function Object: Calculate the standard desviation */
/*****************************************************************/
double StandardDesviation(List<float> numeros)
{
    float average = numeros.Average();
    double sumatoria = numeros.Sum(numero => Math.Pow((numero - average), 2));
    return Math.Sqrt(sumatoria/(numeros.Count() - 1));
}
