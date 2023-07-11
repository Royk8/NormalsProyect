using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporal : MonoBehaviour
{
    public Lista lista;

	private void Start()
	{
		lista = new Lista();
		lista.CrearListaDesdeNumero("1568");

		Debug.Log(lista.DesplegarLista());
	}

}
