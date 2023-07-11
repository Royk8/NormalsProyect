using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JVersus : MonoBehaviour
{
    public string numeroTentativo;
	public InputField texto;
	public Button btnIniciar;
	public Button btnEnviar;

	private void Start()
	{
		btnEnviar.interactable = false;
	}

	public void CambiarNumeroTentativo(string nt)
	{
		numeroTentativo = nt;
	}

	public void IniciarJuego()
	{
		if (Juego.VerificarGramaticaNumero(numeroTentativo))
		{
			Juego.singleton.InicializarL2(numeroTentativo);
			texto.text = "";
			btnIniciar.interactable = false;
			btnEnviar.interactable = true;
			Juego.singleton.InicializarL1(Juego.GenerarNumero());
		}
		else
		{
			Debug.LogError("El numero está mal copiado");
		}

	}

	public void EnviarNumero()
	{
		if (Juego.VerificarGramaticaNumero(numeroTentativo))
		{
			Resultado r = Juego.singleton.CompararNumeroEnL1(numeroTentativo);
			print("El resultado tuyo es => Picas: " + r.picas + " - Fijas: " + r.fijas);
			if (r.fijas == 4)
			{
				print("Ganaste!!!");
			}
			else
			{
				r = Juego.singleton.CompararNumeroEnL2(Juego.GenerarNumero());
				print("El resultado del PC es => Picas: " + r.picas + " - Fijas: " + r.fijas);
				if (r.fijas == 4)
				{
					print("La máquina te ganó!!!");
				}
			}
		}
		else
		{
			Debug.LogError("El numero está mal copiado");
		}
	}
}
