using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JPVP : MonoBehaviour
{
	public string numeroTentativo1;
	public string numeroTentativo2;
	public InputField texto1;
	public InputField texto2;
	public Button btnIniciar1;
	public Button btnEnviar1;
	public Button btnIniciar2;
	public Button btnEnviar2;

	public bool listo1 = false;
	public bool listo2 = false;

	private void Start()
	{
		btnEnviar1.interactable = false;
		btnEnviar2.interactable = false;
	}

	public void CambiarNumeroTentativo1(string nt)
	{
		numeroTentativo1 = nt;
	}
	public void CambiarNumeroTentativo2(string nt)
	{
		numeroTentativo2 = nt;
	}

	public void IniciarJuego1()
	{
		if (Juego.VerificarGramaticaNumero(numeroTentativo1))
		{
			Juego.singleton.InicializarL1(numeroTentativo1);
			texto1.text = "";
			texto1.contentType = InputField.ContentType.IntegerNumber;
			listo1 = true;
			if (listo1 && listo2)
			{
				btnEnviar1.interactable = true;
				btnEnviar2.interactable = false;
			}
			btnIniciar1.interactable = false;
		}
		else
		{
			Debug.LogError("El numero está mal copiado");
		}

	}
	public void IniciarJuego2()
	{
		if (Juego.VerificarGramaticaNumero(numeroTentativo2))
		{
			Juego.singleton.InicializarL2(numeroTentativo2);
			texto2.text = "";
			texto2.contentType = InputField.ContentType.IntegerNumber;
			listo2 = true;
			if (listo1 && listo2)
			{
				btnEnviar1.interactable = true;
				btnEnviar2.interactable = false;
			}
			btnIniciar2.interactable = false;
		}
		else
		{
			Debug.LogError("El numero está mal copiado");
		}

	}


	public void EnviarNumero1()
	{
		if (Juego.VerificarGramaticaNumero(numeroTentativo1))
		{
			Resultado r = Juego.singleton.CompararNumeroEnL2(numeroTentativo1);
			print("El resultado del Jugador 1 es => Picas: " + r.picas + " - Fijas: " + r.fijas);
			if (r.fijas == 4)
			{
				print("Jugador 1 Ganó!!!");
			}
			btnEnviar1.interactable = false;
			btnEnviar2.interactable = true;
		}
		else
		{
			Debug.LogError("El numero está mal copiado");
		}
	}
	public void EnviarNumero2()
	{
		if (Juego.VerificarGramaticaNumero(numeroTentativo2))
		{
			Resultado r = Juego.singleton.CompararNumeroEnL1(numeroTentativo2);
			print("El resultado del Jugador 2 es => Picas: " + r.picas + " - Fijas: " + r.fijas);
			if (r.fijas == 4)
			{
				print("Jugador 2 Ganó!!!");
			}
			btnEnviar2.interactable = false;
			btnEnviar1.interactable = true;
		}
		else
		{
			Debug.LogError("El numero está mal copiado");
		}
	}
}
