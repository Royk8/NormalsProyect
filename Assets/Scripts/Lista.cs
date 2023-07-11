[System.Serializable]
public class Lista
{
    public Nodo cabeza;
    public Nodo cola;

	public Lista()
	{
        cabeza = null;
	}

    public void AgregarNodo(int numero)
	{
        Nodo n = new Nodo(numero);
		if (cabeza == null)
		{
			cabeza = n;
			cola = n;
		}
		else
		{
			cola.siguiente = n;
			cola = n;
		}
	}

	public string DesplegarLista()
	{
		if (cabeza == null)
		{
			return "[vacia]";
		}

		string l = "";

		Nodo n = cabeza;

		do
		{
			l += "" + n.numero;
			n = n.siguiente;
		} while (n != null);

		return l;
	}

	public void CrearListaDesdeNumero(string numero)
	{
		for (int i = 0; i < numero.Length; i++)
		{
			int num = int.Parse(numero[i].ToString());
			AgregarNodo(num);
		}
	}

	public Resultado Verificar(string numeros)
	{
		Resultado r = new Resultado();

		r.picas = BuscarPicas(DesplegarLista(), numeros);
		r.fijas = BuscarFijas(DesplegarLista(), numeros);

		return r;
	}



	int BuscarPicas(string n1, string n2)
	{
		int i2 = 0;
		for (int i = 0; i < n2.Length; i++)
		{
			for (int j = 0; j < n1.Length; j++)
			{
				i2 += (i!=j && n1[i].Equals(n2[j]))?1:0;
			}
		}
		return i2;
	}
	
	int BuscarFijas(string n1, string n2)
	{
		int i = 0;
		for (int j = 0; j < n2.Length; j++)
		{
			i += n1[j].Equals(n2[j]) ? 1 : 0;
		}
		return i;
	}

}

[System.Serializable]
public class Nodo
{
    public int numero;
    public Nodo siguiente;

    public Nodo(int _numero)
	{
        numero = _numero;
		siguiente = null;
	}
}


[System.Serializable]
public class Resultado
{
	public int picas;
	public int fijas;
}