using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juego : MonoBehaviour
{
    public Lista l1;
    public Lista l2;

    public static Juego singleton;

	private void Awake()
	{
		if (singleton != null)
		{
            DestroyImmediate(this);
		}
		else
		{
            singleton = this;
		}
	}

	public void InicializarL1(string numero)
    {
        l1 = new Lista();
        l1.CrearListaDesdeNumero(numero);
    }
    public void InicializarL2(string numero)
    {
        l2 = new Lista();
        l2.CrearListaDesdeNumero(numero);
    }

    public Resultado CompararNumeroEnL1(string nX)
	{
        return CompararNumeroEnLista(1, nX);
    }
    public Resultado CompararNumeroEnL2(string nX)
    {
        return CompararNumeroEnLista(2, nX);
    }

    public Resultado CompararNumeroEnLista(int l, string nX)
    {
        Lista L;
		if (l == 1)
		{
            L = l1;
		}
		else
		{
            L = l2;
		}
        return  L.Verificar(nX);
    }

    public static bool VerificarGramaticaNumero(string n)
	{
        if (n.Length != 4) return false;
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				if (i != j && n[i].Equals(n[j]))
				{
                    return false;
				}
			}
		}
        return true;
	}


	public static string GenerarNumero()
	{
		List<int> listaNumeros = new List<int>();
		for (int i = 0; i < 10; i++)
		{
			listaNumeros.Add(i);
		}

		List<int> listaDesordenada = new List<int>();
		while (listaNumeros.Count > 0)
		{
			int rnd = Random.Range(0, listaNumeros.Count);
			listaDesordenada.Add(listaNumeros[rnd]);
			listaNumeros.RemoveAt(rnd);
		}

		return (listaDesordenada[0].ToString() + listaDesordenada[1].ToString() + listaDesordenada[2].ToString() + listaDesordenada[3].ToString());

	}

}
