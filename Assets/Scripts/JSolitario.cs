using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSolitario : MonoBehaviour
{
    public string numeroTentativo;


	private void Start()
	{
		Juego.singleton.InicializarL1(Juego.GenerarNumero());
	}

	public void CambiarNumeroTentativo(string nt)
	{
		numeroTentativo = nt;
	}

	public void EnviarNumero()
	{
		if (Juego.VerificarGramaticaNumero(numeroTentativo))
		{
			Resultado r = Juego.singleton.CompararNumeroEnL1(numeroTentativo);
			print("Picas: " + r.picas + " - Fijas: " + r.fijas);
			if (r.fijas == 4)
			{
				print("Victoria!");
			}

		}
		else
		{
			Debug.LogError("El numero está mal copiado");
		}
	}

}
