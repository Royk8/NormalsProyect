using UnityEngine;

public class Camara : MonoBehaviour{

	public static bool PRIMERA_PERSONA;

	public Camera camaraDelantera;
	public Camera camaraTrasera;
	public Camera camaraSuperior;
	public Camera camaraInterior;//camara piloto
	//faltaria una camara copiloto, para que cuando este jugando en modo online, el usuario, pueda invitar a otro usuario a su coche y a este se le active esta camara

	public GameObject pantalla;
	
	public RenderTexture textureRendered;
	public Material materialPantalla;

    private Camera[] camarasJuego;
    private Camera[] camarasPantalla;

    void Start(){
	
	    camaraDelantera.GetComponent<Camera>();
	    camaraTrasera.GetComponent<Camera>();
	    camaraSuperior.GetComponent<Camera>();
	    camaraInterior.GetComponent<Camera>();

//      camaraInterior.stereoEnabled = true;

	    camarasJuego = new Camera[] {camaraTrasera, camaraInterior};
            // y a este se le añaderia la camara copiloto, anteriormente indicada
	    camarasPantalla = new Camera[] {camaraDelantera, camaraSuperior, camaraTrasera};

	    textureRendered = GetComponent<RenderTexture>();//(RenderTextureFormat.ARGB32);
		/*
		(CamarasOptions.pantalla.width(), CamarasOptions.pantalla.height(), 16,
		RenderTextureFormat.format = RenderTextureFormat.Default, RenderTextureReadWrite.readWrite = RenderTextureReadWrite.Default);
		*/
//	materialPantalla= new Material(textureRendered);
		//https://docs.unity3d.com/ScriptReference/Shader.html
        //falta crear el materia, ver si hacen falta crear tantos materiales como pantallas
	    materialPantalla=pantalla.GetComponent<Material>();

        /*
            // Obtener el Renderer del GameObject 
            m_Renderer = GetComponent < Renderer > (); 

            // Asegúrese de habilitar las palabras clave
            m_Renderer.material.EnableKeyword ("_NORMALMAP");
            m_Renderer.material.EnableKeyword ("_METALLICGLOSSMAP"); 

            // Establezca la textura que asigna en el Inspector como la textura principal (o albedo)
            m_Renderer.material.SetTexture ("_ MainTex", m_MainTexture);
            // Establece el mapa Normal usando la Textura que asignas en el Inspector
            m_Renderer.material.SetTexture ("_ BumpMap", m_Normal);
            // Establece la textura metálica como una textura que asignes en el Inspector
            m_Renderer.material.SetTexture ("_MetallicGlossMap", m_Metal);
        */
        //		camaraTrasera = Camera.main;       //   hago esto para que sea con la camara que se inicia en esta escena
        //  textureRendered.height = 0.0931099; //  93.1099 / 1000;
        //  textureRendered.width = 0.2373212;  //  237.3212 / 1000;

    }
	
	void FixedUpdate(){
		CambioCamara();
/*		if(PRIMERA_PERSONA){
			RepresentacionPantalla();
			Retrovisores();
		}
*/
	}
	
    
    private bool CambioCamara(){

	//	https://docs.unity3d.com/ScriptReference/ObjectFactory.AddComponent.html

	//crear otra pantalla con la telemetria del coche
	//poner en la pantalla del interior lo que devulve las siguientes camaras

		for(byte h=0; h>=camarasJuego.Length; h=h){	//nullRefencesException
			if(Input.GetKeyDown(KeyCode.C)){
                h++;
                Camera camaraJuego = camarasJuego[h];
				camaraJuego.enabled=true;
				camaraJuego.farClipPlane=150;	//a la distacia donde la camara deja de renderizar
Debug.Log("se cambia la camara");
				if(h==1 && Input.GetKeyDown(KeyCode.C)){
					h=0;
					PRIMERA_PERSONA=false;
Debug.Log("se ha cambiado la camara exterior, primera persona ="+PRIMERA_PERSONA+camaraJuego);
				}
				if(h==1){
					PRIMERA_PERSONA=true;
Debug.Log("se ha cambiado la camara exterior, primera persona ="+PRIMERA_PERSONA);
					for(byte p=0; p>=camarasPantalla.Length; p=p){	//nullRefencesException
						if(Input.GetKeyDown(KeyCode.Z)){
							Camera camaraPantalla = camarasPantalla[p];
							camaraPantalla.enabled=true;
							camaraPantalla.nearClipPlane=0.5f;	//a la distancia donde la camara empiza a renderizar
							camaraPantalla.farClipPlane=300;	//a la distancia donde la camara termina de renderizar
Debug.Log("se cambia la camara en la pantallla");
							p++;
							RepresentacionPantalla(camaraPantalla);     //  https://www.youtube.com/watch?v=Goqe5IorfN0
			//				textureRendered =pantalla.GetComponent<TextureRender>();
							camaraPantalla.targetTexture=textureRendered;
							//https://docs.unity3d.com/ScriptReference/Camera-targetTexture.html
Debug.Log("se ha cambiado la camara interior");
						}
						if(p==camarasPantalla.Length && Input.GetKeyDown(KeyCode.Z)){
							p=0;
Debug.Log("se ha cambiado la camara interior y vuelve al principio");
						}
					}
				}	
			}
		}
		return PRIMERA_PERSONA;
    }

	private void RepresentacionPantalla(Camera camara){ //https://www.youtube.com/watch?v=Px7Iy8STnZA
        materialPantalla = pantalla.GetComponentInChildren<Material>();
        textureRendered = camara.targetTexture; // camara.targetTexture = textureRendered;
//        materialPantalla.GetTexture.Albedo = textureRendered;
        materialPantalla.SetTexture("Albedo", textureRendered);
//        materialPantalla.mainTexture.Albedo = textureRendered;
Debug.Log("representacion en la pantalla de la camara " + camara);
    }

}

/*
https://www.youtube.com/watch?v=u1dLdXBTBB8		Acceder a variables y funciones entre Scripts | Tutorial Unity 5
https://www.youtube.com/watch?v=JH2HA6EJ56A		Guardar y cargar datos simples con PlayerPrefs | Tutorial Unity 5
https://www.youtube.com/watch?v=3tzoxfajCU8		Guardar objetos en ficheros JSON (1/2) Serializar Objetos | Tutorial Unity 5
https://www.youtube.com/watch?v=MyvbFXwwLww		Guardar objetos en ficheros JSON (2/2) Serializar Listas | Tutorial Unity 5
https://www.youtube.com/watch?v=LCHnFlCTHgg		Barra de vida simple (1/2) Preparando el canvas | Tutorial Unity 5
https://www.youtube.com/watch?v=nsoygL0n5rQ		Barra de vida simple (2/2) Agregando funcionalidad | Tutorial Unity 5
https://www.youtube.com/watch?v=gxLwdADJqZo		Pausa de juego fácil con mensaje | Tutorial Unity 5
https://www.youtube.com/watch?v=ttSfrh86BJo		Menú fácil pero resultón | Tutorial Unity 5
https://www.youtube.com/watch?v=IZ4eiIf3DBY		Tutorial Unity 5: Instalación y Primer Uso | Mi Aprendizaje [#1]
https://www.youtube.com/watch?v=vTXKe1ooOnk		Tutorial Unity 5: Componentes de GUI | Mi Aprendizaje [#2]
https://www.youtube.com/watch?v=-TobfKcKzhs		Tutorial Unity 5: Menús y Escenas | Mi Aprendizaje [#3]
https://www.youtube.com/watch?v=EZ4TJg4ku9Y		Crea tus librerías de código C# reutilizable | Tutorial Unity 5

https://www.youtube.com/watch?v=se4JoqzOzYk     Crea un Juego ONLINE en Unity con Photon Network 📡 [1]
https://www.youtube.com/watch?v=8EYyTlVnKCw     Sincronizando Datos entre Jugadores 📡 [2] Crea un Juego ONLINE en Unity con Photon Network
https://www.youtube.com/watch?v=JVj1tgCbpus     Instanciación de Objetos de Red 📡 [3] Crea un Juego ONLINE en Unity con Photon Network

https://www.youtube.com/watch?v=yS_bHPSsACY     8.1 - Multiplayer: introducción Photon 2 -Crea un BATTLE ROYALE Unity -tutorial español
https://www.youtube.com/watch?v=Z0aX7jvy7Lo     8.2 - Multiplayer: Transform y Animations (Photon 2) -Crea un BATTLE ROYALE Unity -tutorial español
https://www.youtube.com/watch?v=JPFhnEir0zc     8.3 - Multiplayer: Scene Load y Player Instantiation -Crea un BATTLE ROYALE Unity -tutorial español
https://www.youtube.com/watch?v=easw0HKxc3g     El Coste de Crear y Mantener un Juego Multiplayer (Photon 2 - MAD.Review)

    https://www.youtube.com/watch?v=o4QAA2HXvQU Cómo Crear un Battle Royale con #Unity 2020 Tutorial Español en Directo
https://www.youtube.com/watch?v=G1uVqtWm4Nk     1. UNITY MULTIPLAYER 01: Creando un juego multijugador en UNITY 3D.
https://www.youtube.com/watch?v=8fUP3dn8pgk     2. UNITY Multiplayer: Configuración para la conexión del jugador a Photon Network. Juego 3D.
https://www.youtube.com/watch?v=D4Ei_qCkAoY     3- UNITY Mutiplayer: Creando los paneles para usuario y acceso a salas. Obteniendo avatars.
https://www.youtube.com/watch?v=TX3bzuWk0Ck     4- UNITY Multiplayer 3D: Creando un selector de avatars del jugador.
https://www.youtube.com/watch?v=NJ9O-zyhFo0     5- UNITY 3D Multiplayer: Creación de un selector de Avatars Parte II.
https://www.youtube.com/watch?v=xjN-q2FQP_0     6- UNITY Multiplayer con Photon 2: Obteniendo acceso a salas de juego
https://www.youtube.com/watch?v=D1B1KmPxYEY     7- UNITY Multiplayer: Probando el acceso simultáneo de 2 jugadores a la misma sala de juego.
https://www.youtube.com/watch?v=H0Jq17UqmpQ     8- UNITY Multiplayer: Elaborando una plataforma de acceso multiplayer. Lobbies y salas.
https://www.youtube.com/watch?v=DBVCZWXSfZM     9- UNITY Multiplayer: Probando el acceso y cambio de salas con instancias ejecutables

https://www.youtube.com/watch?v=JYMFqQVl2js     1- UNITY 3D Multijugador con Photon 2. Creando una carrera de automóviles PASO A PASO.
https://www.youtube.com/watch?v=GCaFUNIoF_M     2- UNITY 3D Multijugador video Nro. 2. Script controlador de red y panel de acceso de jugador.
https://www.youtube.com/watch?v=SjG_CmoBj80     3- UNITY 3D Multijugador. Enlazando datos del panel de inicio y carga de paneles de usuario.
https://www.youtube.com/watch?v=HoZH5w1Pu7Y     4- UNITY Multijugador 3D con Photon: Preparación de paneles de usuario e ingreso a sala de juego.
https://www.youtube.com/watch?v=w_jbDq8GgJ0     5 - UNITY 3D Multiplayer: Configurando la interface de usuario para seleccionar el auto de carreras.
https://www.youtube.com/watch?v=HP_IhiPg3WI     UNITY Multijugador. Tutorial. Mejorando interfaces, métodos OnPlayerEntered y OnPlayerLeft room.
https://www.youtube.com/watch?v=sLNUvbLfAm8&list=PLI1Kwt1N0_YmwMROS7XLvfJal3YEBLdj0&index=6     UNITY MultiPlayer: 1. Introducción a Photon Chat
https://www.youtube.com/watch?v=sbMtF2uP0Jk&list=PLI1Kwt1N0_YmwMROS7XLvfJal3YEBLdj0&index=7     UNITY MultiPlayer: 2. Scripts para Photon Chat: IChatListener



*/
