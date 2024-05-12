﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using System.Threading;

using chatbot_wathsapp.clases.herramientas;
using OpenQA.Selenium.Interactions;
using Microsoft.SqlServer.Server;



namespace chatbot_wathsapp.clases
{
    class chatbot_clase
    {
        operaciones_arreglos op_arr = new operaciones_arreglos();
        operaciones_textos op_tex = new operaciones_textos();
        var_fun_GG var_GG = new var_fun_GG();
        Tex_base bas = new Tex_base();
        mult simul = new mult();

        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        string[] G_dir_arch_conf_chatbot =
        {
            /*0*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[5, 0],//"config\\chatbot\\info_para_comandos_chatbot\\00_paginaweb.txt",
            /*1*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[6, 0],//"config\\chatbot\\info_para_comandos_chatbot\\01_ya_entrado_en_la_mensajeria.txt",
            /*2*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[7, 0],//"config\\chatbot\\info_para_comandos_chatbot\\02_chequeo_no_leidos.txt",
            /*3*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[8, 0],//"config\\chatbot\\info_para_comandos_chatbot\\03_clickeo.txt",
            /*4*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[9, 0],//"config\\chatbot\\info_para_comandos_chatbot\\04_lectura_del_mensage.txt",
            /*5*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[10, 0],//"config\\chatbot\\info_para_comandos_chatbot\\05_reconocer_textbox_de_envio.txt",
            /*6*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[11, 0],//"config\\chatbot\\info_para_comandos_chatbot\\06_buscar_nombre.txt",
            /*7*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[12, 0],//"config\\chatbot\\info_para_comandos_chatbot\\07_nombre_del_clikeado.txt",

        };

        string[] G_dir_arch_mensages =
        {
            /*0*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[13, 0],//"config\\chatbot\\01_mensaje_bienvenida_inicio.txt,",
            /*1*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[14, 0],//"config\\chatbot\\02_mensaje_bienvenida_final.txt",
            /*2*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[15, 0],//"config\\chatbot\\03_productos.txt",
            /*3*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[16, 0],//"config\\chatbot\\04_mensaje_extra_despues_de_la_venta.txt"
            /*2*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[29, 0]//"config\\chatbot\\03_productos.txt",

        };
        string[,] G_contactos_lista_para_mandar_informacion =
        {
            /*0*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[17, 0],"encargados" },
            /*1*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[18, 0],"supervisores" },
            /*2*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[19, 0],"contadores" },
            /*3*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[20, 0],"vendedores" },
            /*4*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[21, 0],"repartidores" },
            /*5*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[22, 0],"reg_mensage" },
            /*6*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[26, 0],"tesoreros" },
            /*7*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[23, 0],"programador" },
            /*8*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[31, 0],"pedidos_horario" },
            /*9*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[30, 0],"confirmadores" },
            /*10*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[35, 0],"cocina_fonda" },
        };

        public string[,] G_dir_para_registros_y_configuraciones =
        {
            /*0*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[25,0] ,"folios_a_procesar" },//"config\\chatbot\\registros\\folios_a_checar\\folio_ventas.txt,"
            /*1*/{ "config\\chatbot\\registros\\" + Tex_base.GG_año_mes_dia_para_registros_ + "_reg.txt", "registro" },
            /*2*/{ "config\\chatbot\\registros\\" + Tex_base.GG_año_mes_dia_para_registros_ + "_usuarios_reg.txt", "registro_usuario_venta_por_dia" },
            /*3*/{ Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[24, 0], "chequeo_recarga_de_arreglos" }
        };


        public string[] G_dir_arch_transferencia =
        {
            /*0*//*1*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\no_hacer_caso.txt",//no_hacer_caso
            /*1*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\1.txt",//preguntas
            /*2*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\2.txt",//respuestas
            /*3*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\3.txt",//pedidos
            /*4*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\4.txt",//agregar preguntas para_watsap desde el watsap o lectura del chatbot depende la bandera
            /*5*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\5.txt",//agregar respuestas  para_chatbot desde el watsap o lectura del chatbot depende la bandera
            /*6*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\6.txt",//agregar pedidos para_watsap desde el watsap o lectura del chatbot depende la bandera
            /*7*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\7.txt",//agregar pregunta  para_chatbot desde el watsap o lectura del chatbot depende la bandera
            /*8*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\8.txt",//agregar respuesta para_watsap desde el watsap o lectura del chatbot depende la bandera
            /*9*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\9.txt",//agregar pedidos  para_chatbot desde el watsap o lectura del chatbot depende la bandera
            /*10*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\10.txt",//agregar pregunta  para_chatbot desde el watsap o lectura del chatbot depende la bandera
            /*11*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\11.txt",//agregar respuesta para_watsap desde el watsap o lectura del chatbot depende la bandera
            /*12*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\12.txt",//agregar pedidos  para_chatbot desde el watsap o lectura del chatbot depende la bandera
        };
        public string G_direccion_de_banderas_transferencias =/*0*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\xerox\\config\\inf\\bklkfjc\\b.txt";



        string[][] G_info_de_configuracion_chatbot = null;

        string G_direccion_negocio = Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[2, 0];//string G_direccion_negocio = "config\\sismul2\\negocio.txt";


        string[,] G_productos = new string[10, 3];



        public void configuracion_de_inicio()
        {


            G_info_de_configuracion_chatbot = extraer_info_de_archivos_de_configuracion_chatbot(G_dir_arch_conf_chatbot);

            //<span class="l7jjieqr cfzgl7ar ei5e7seu h0viaqh7 tpmajp1w c0uhu3dl riy2oczp dsh4tgtl sy6s5v3r gz7w46tb lyutrhe2 qfejxiq4 fewfhwl7 ovhn1urg ap18qm3b ikwl5qvt j90th5db aumms1qt"
            //aria-label="No leídos">1</span>

            int tiempo_en_segunds_espera = 40;
            int tiempo_en_minutos = 5;


            //damos algunas opciones para iniciar el chomer
            var opciones = new ChromeOptions();
            opciones.AddArguments("--start-maximized");
            opciones.AddExcludedArgument("enable-automation");

            //declaramos el elemento manejadores
            var manejadores = new ChromeDriver(opciones);
            manejadores.Navigate().GoToUrl(G_info_de_configuracion_chatbot[0][1]);

            //declaramos un elemento esperarque nos ayude a evitar erroes de elementos no encontrados
            var esperar = new WebDriverWait(manejadores, TimeSpan.FromMinutes(tiempo_en_minutos));//segun 5 min es suficiente pero no hace  la espera
            //Thread.Sleep(tiempo_en_segunds_espera * 1000);//puse este yo para que se haga la espera

            //esperar.Until(manej => manej.FindElement(By.Id("side")));//este es un id que aparece despues de escanear el codigo

            esperar.Until(manej =>
            {
                //IWebElement elemento_app = manej.FindElement(By.Id("app"));
                IWebElement elementoSide = manej.FindElement(By.Id(G_info_de_configuracion_chatbot[1][1]));
                return elementoSide;
            });

            procesos(manejadores, esperar);

        }

        public void procesos(IWebDriver manejadores, WebDriverWait esperar)
        {

            //estos son del no leido--------------------------------------------------------------------
            string elementos = G_info_de_configuracion_chatbot[2][1];
            string elementos_clase = elementos + G_info_de_configuracion_chatbot[3][1];
            //-----------------------------------------------------------------------------------------

            //------------------------------------------------------------------------------------------


            while (true)
            {
                try
                {


                    //checa si estan los elementos  esto sustitulle al // esperar.Until(manej => manej.FindElement(By.XPath(elementos)));//busca el elemento del no leido
                    //porque siempre marcaba error
                    bool elementoEncontrado = false;
                    elementoEncontrado = esperar.Until(manej =>
                    {
                        var cuantos_elementos = manej.FindElements(By.XPath(elementos));
                        if (cuantos_elementos.Count > 0)
                        {
                            // Si el elemento está presente, retorna verdadero
                            //clickea
                            try
                            {
                                manejadores.FindElement(By.XPath(elementos_clase)).Click();//clickea el elemento del no leido
                               string[] textosDelMensaje = leer_mensages_recibidos_del_mensage_clickeado(manejadores, esperar);
                                string nom_del_click = nombre_del_clickeado(manejadores, esperar);
                                //fin mensaje que resibio--------------------------------------------------------------

                                Thread.Sleep(1000);
                                modelo_para_mandar_mensage_archivo_ia(manejadores, esperar, nom_del_click, textosDelMensaje);
                            }
                            catch
                            {

                                
                            }
                            

                            Thread.Sleep(1000);

                            return true;
                        }
                        else
                        {

                            datos_salida_y_borrado(manejadores, esperar);


                            Thread.Sleep(1000); // Puedes ajustar el tiempo de espera según tu escenario
                            return false;
                        }
                    });
                    //---------------------------------------------------------------------------------------------
                    //

                }
                catch (NoSuchElementException ex) { }

                catch (Exception ex) { }

                catch { }

            }

        }




        private void modelo_para_mandar_mensage_archivo_ia(IWebDriver manejadores, WebDriverWait esperar, string nombre_Del_que_envio_el_mensage, object texto_recibidos_arreglo_objeto)
        {

            string[] textos_recibidos_srting_arr = op_arr.convierte_objeto_a_arreglo(texto_recibidos_arreglo_objeto);
            string ultimo_mensaje = textos_recibidos_srting_arr[textos_recibidos_srting_arr.Length - 1].ToLower();//ultimo mensaje lo pone en minusculas

            mandar_mensage_usuarios(manejadores, esperar, G_contactos_lista_para_mandar_informacion[5, 1], nombre_Del_que_envio_el_mensage + "\n" + ultimo_mensaje + "\n--------------------------------------------------------------------");

            string[] lineas_del_mensaje = ultimo_mensaje.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            string lineas_joineadas = op_tex.joineada_paraesida_SIN_NULOS_y_quitador_de_extremos_del_string(lineas_del_mensaje, "  ");

            datos_entrada(nombre_Del_que_envio_el_mensage, lineas_joineadas);




            Actions action = new Actions(manejadores);
            action.SendKeys(Keys.Escape).Perform();


        }

        private void buscar_nombre_y_dar_click(IWebDriver manejadores, WebDriverWait esperar, string nombre_o_numero)
        {
            Actions action = new Actions(manejadores);
            action.SendKeys(Keys.Escape).Perform();

            //buscamos persona en el buscador de personas
            //aqui hacemos que reconosca la barra de texto y escriba

            string lugar_a_escribir = G_info_de_configuracion_chatbot[5][2];
            //var escribir_msg = G_esperar2.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));
            var escribir_msg = esperar.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));

            escribir_msg.SendKeys(nombre_o_numero);
            escribir_msg.SendKeys(Keys.Enter);


            /* lla funciona con el enter que se le da en busqueda asi que no es nesesario
            //damos click
            IWebDriver manejadores_de_busqueda = manejadores;
            //ReadOnlyCollection<IWebElement> elementos = manejadores_de_busqueda.FindElements(By.XPath("//span[contains(@title, 'Jorge')]"));
            string buscar_elemento = G_info_de_configuracion_chatbot[6][1] + nombre_o_numero + "')]";
            IWebElement elemento = manejadores_de_busqueda.FindElement(By.XPath(buscar_elemento));
            string a = elemento.Text;
            elemento.Click();
            */

            //limpiamos_lo_que_se_puso_en_el_buscador_de_contactos
            escribir_msg.Click(); // Enfocar el elemento
            for (int i = 0; i < nombre_o_numero.Length; i++)
            {
                escribir_msg.SendKeys(Keys.Backspace); // Borrar el contenido del textbox
            }


        }

        private void mandar_mensage_usuarios(IWebDriver manejadores, WebDriverWait esperar, object nombre_contacto, string mensage = null, object caracter_separacion_objeto_usuarios = null, object caracter_separacion_objeto_mensages = null)
        {

            string[] caracter_separacion_usuarios = var_GG.GG_funcion_caracter_separacion(caracter_separacion_objeto_usuarios);
            string[] caracter_separacion_mensajes = var_GG.GG_funcion_caracter_separacion_funciones_especificas(caracter_separacion_objeto_mensages);
            string[] supervisores = op_arr.convierte_objeto_a_arreglo(nombre_contacto, caracter_separacion_usuarios[0]);
            string[] mensage_espliteados = op_arr.convierte_objeto_a_arreglo(mensage, caracter_separacion_mensajes[0]);
            bool encontro_al_supervisor = false;
            for (int k = 0; k < supervisores.Length; k++)
            {


                for (int h = 0; h < G_contactos_lista_para_mandar_informacion.GetLength(0); h++)
                {

                    if (supervisores[k] == G_contactos_lista_para_mandar_informacion[h, 1])
                    {
                        encontro_al_supervisor = true;
                        // Simular la presión de la tecla Escape
                        Actions action = new Actions(manejadores);
                        action.SendKeys(Keys.Escape).Perform();

                        int indice_supervisor = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_contactos_lista_para_mandar_informacion[h, 0]));
                        for (int l = G_donde_inicia_la_tabla; l < Tex_base.GG_base_arreglo_de_arreglos[indice_supervisor].Length; l++)
                        {
                            buscar_nombre_y_dar_click(manejadores, esperar, Tex_base.GG_base_arreglo_de_arreglos[indice_supervisor][l]);
                            mandar_mensage(esperar, mensage_espliteados[k]);
                        }

                    }
                }

                if (supervisores[k] == "usuario_actual")
                {
                    encontro_al_supervisor = true;
                    mandar_mensage(esperar, mensage_espliteados[k]);
                }

                if (encontro_al_supervisor == false)
                {
                    if (nombre_contacto is string)
                    {
                        buscar_nombre_y_dar_click(manejadores, esperar, (string)nombre_contacto);
                        mandar_mensage(esperar, mensage_espliteados[k]);
                    }

                }



            }


        }

        //WebDriverWait G_esperar2;
        private void mandar_mensage(WebDriverWait esperar, object texto_enviar_arreglo_objeto)
        {
            string[] texto_enviar_arreglo_string = op_arr.convierte_objeto_a_arreglo(texto_enviar_arreglo_objeto, "\n");


            //G_esperar2 = esperar;
            //aqui hacemos que reconosca la barra de texto y escriba

            string lugar_a_escribir = G_info_de_configuracion_chatbot[5][1];
            //var escribir_msg = G_esperar2.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));
            var escribir_msg = esperar.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));
            string texto_enviar = string.Join("\n", texto_enviar_arreglo_string);

            escribir_msg.SendKeys(texto_enviar);
            Thread.Sleep(1000); // Puedes ajustar el tiempo de espera según tu escenario
            escribir_msg.SendKeys(Keys.Enter);

        }

        private string[] leer_mensages_recibidos_del_mensage_clickeado(IWebDriver manejadores, WebDriverWait esperar)
        {

            //estos son los de buscar el mensage que nos llego
            string elementos2 = G_info_de_configuracion_chatbot[4][1];

            ReadOnlyCollection<IWebElement> elementos_ = esperar.Until(manej3 => manej3.FindElements(By.XPath(elementos2)));

            string[] textosDelMensaje = new string[elementos_.Count];
            for (int i = 0; i < elementos_.Count; i++)
            {
                textosDelMensaje[i] = elementos_[i].Text;
            }
            return textosDelMensaje;
        }

        private string nombre_del_clickeado(IWebDriver manejadores, WebDriverWait esperar)
        {
            string nombre_a_devolver = esperar.Until(manej2 =>
            {
                try
                {
                    return manej2.FindElement(By.XPath(G_info_de_configuracion_chatbot[7][1])).Text;
                }
                catch
                {

                    return manej2.FindElement(By.XPath(G_info_de_configuracion_chatbot[7][2])).Text;

                }

            });



            return nombre_a_devolver;

        }



        string[,] mensajes_acumulados = null;
        public string[,] acumulador_de_mensajes(string nombre = null, string mensge = null, string operacion = "agregar")
        {
            if (operacion == "agregar")
            {
                mensajes_acumulados = op_arr.agregar_registro_del_array_bidimensional(mensajes_acumulados, nombre + G_caracter_separacion_funciones_espesificas[0] + mensge, G_caracter_separacion_funciones_espesificas[0]);
                return null;
            }
            else if (operacion == "retornar")
            {
                string[,] tem_mensages = mensajes_acumulados;
                mensajes_acumulados = null;
                return tem_mensages;
            }
            return null;
        }

        public void mandar_mensages_acumulados(IWebDriver manejadores, WebDriverWait esperar)
        {
            //retornar mensages acumulados
            string[,] mensajes_para_y_mensaje = acumulador_de_mensajes(operacion: "retornar");
            //mandar mensages
            if (mensajes_para_y_mensaje != null)
            {
                //ordenar
                for (int i = 0; i < mensajes_para_y_mensaje.GetLength(0); i++)
                {
                    if (mensajes_para_y_mensaje[i, 0] != "usuario_actual")
                    {

                        for (int k = i + 1; k < mensajes_para_y_mensaje.GetLength(0); k++)
                        {
                            if (mensajes_para_y_mensaje[k, 0] == "usuario_actual")
                            {
                                // Almacenar la fila actual en una variable temporal
                                string tempUsuario = mensajes_para_y_mensaje[i, 0];
                                string tempMensaje = mensajes_para_y_mensaje[i, 1];

                                // Intercambiar toda la fila
                                mensajes_para_y_mensaje[i, 0] = mensajes_para_y_mensaje[k, 0];
                                mensajes_para_y_mensaje[i, 1] = mensajes_para_y_mensaje[k, 1];
                                mensajes_para_y_mensaje[k, 0] = tempUsuario;
                                mensajes_para_y_mensaje[k, 1] = tempMensaje;

                            }
                        }
                    }
                }

                for (int i = 0; i < mensajes_para_y_mensaje.GetLength(0); i++)
                {
                    mandar_mensage_usuarios(manejadores, esperar, mensajes_para_y_mensaje[i, 0], mensajes_para_y_mensaje[i, 1]);
                }
            }




        }

        public string quitando_el_primeros_caracters_y_checa_si_es_int(string dato_a_checar, int numero_de_caracteres_a_quitar = 1)
        {
            string dato_sin_el_primer_caracter = op_tex.joineada_paraesida_y_quitador_de_extremos_del_string(dato_a_checar, restar_cuantas_ultimas_o_primeras_celdas: numero_de_caracteres_a_quitar, restar_primera_celda: true);
            try
            {
                int numero_a_retornar = Convert.ToInt32(dato_sin_el_primer_caracter);
                return "" + numero_a_retornar;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private string[][] extraer_info_de_archivos_de_configuracion_chatbot(string[] direcciones)
        {

            string[][] info_a_retornar = null;
            for (int i = 0; i < direcciones.Length; i++)
            {
                int indice_configuracion_archivos_chatbot = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direcciones[i]));
                info_a_retornar = op_arr.agregar_arreglo_a_arreglo_de_arreglos(info_a_retornar, Tex_base.GG_base_arreglo_de_arreglos[indice_configuracion_archivos_chatbot]);
            }

            return info_a_retornar;
        }

        private void regresr_respuesta_ia(IWebDriver manejadores, WebDriverWait esperar, string nombre_Del_que_envio_el_mensage, string texto_recibidos_arreglo)
        {

            mandar_mensage_usuarios(manejadores, esperar, G_contactos_lista_para_mandar_informacion[5, 1], "ia_" + nombre_Del_que_envio_el_mensage + "\n" + texto_recibidos_arreglo + "\n--------------------------------------------------------------------");
            Actions action = new Actions(manejadores);
            action.SendKeys(Keys.Escape).Perform();
            mandar_mensage_usuarios(manejadores, esperar, nombre_Del_que_envio_el_mensage, texto_recibidos_arreglo);


            action = new Actions(manejadores);
            action.SendKeys(Keys.Escape).Perform();


        }

        public int[] checar_numero_de_direccion_de_archivo_atras_actual_adelante(int posicion_bandera)
        {
            string[] banderas = bas.Leer_inicial(G_direccion_de_banderas_transferencias);



            int numero_actual_posision = Convert.ToInt32(banderas[posicion_bandera]);
            int numero_adelante_posision = numero_actual_posision + 3;
            int numero_atras_posision = numero_actual_posision - 3;
            int[] arr_devolver = { -1, -1, -1 };


            if (G_dir_arch_transferencia.Length <= numero_adelante_posision)
            {
                if (numero_adelante_posision < 3)
                {
                    numero_adelante_posision = posicion_bandera;
                }
                else
                {
                    numero_adelante_posision = posicion_bandera;
                    while (numero_adelante_posision > 3)
                    {
                        numero_adelante_posision = numero_adelante_posision - 3;
                    }
                }
            }
            if (1 > numero_actual_posision - 3)
            {
                numero_atras_posision = (G_dir_arch_transferencia.Length - 4) + posicion_bandera;
            }
            arr_devolver[0] = numero_atras_posision;
            arr_devolver[1] = numero_actual_posision;
            arr_devolver[2] = numero_adelante_posision;




            return arr_devolver;

        }


        public void datos_entrada(string contacto, string mensage, string ia_ws = "ws")
        {
            int[] id_atras_actual_adelante_ia_1 = checar_numero_de_direccion_de_archivo_atras_actual_adelante(1);//esta es de la ia
            int[] id_atras_actual_adelante_ws_2 = checar_numero_de_direccion_de_archivo_atras_actual_adelante(4);//este es del ws

            if (ia_ws == "ws")//agrega a archivos pregunta de la ia
            {

                recargar_arreglos();

                string mensage1 = "";
                string mensage2 = "";
                string mensage3 = "";
                string contacto_solo_los_ultimos_digitos = "";
                for (int i = 0; i < 4 && i < contacto.Length; i++)
                {
                    contacto_solo_los_ultimos_digitos = contacto[(contacto.Length - 1) - i] + "" + contacto_solo_los_ultimos_digitos;
                }

                for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[13].Length; i++)
                {
                    mensage1 = op_tex.concatenacion_caracter_separacion(mensage1, Tex_base.GG_base_arreglo_de_arreglos[13][i], "           ");
                }
                for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[14].Length; i++)
                {
                    mensage2 = op_tex.concatenacion_caracter_separacion(mensage2, Tex_base.GG_base_arreglo_de_arreglos[14][i], "           ");
                }

                for (int i = G_donde_inicia_la_tabla; i < Tex_base.GG_base_arreglo_de_arreglos[15].Length; i++)
                {
                    mensage3 = op_tex.concatenacion_caracter_separacion(mensage3, Tex_base.GG_base_arreglo_de_arreglos[15][i], "           ");
                }

                if (id_atras_actual_adelante_ws_2[1] == id_atras_actual_adelante_ia_1[1] || id_atras_actual_adelante_ws_2[0] == id_atras_actual_adelante_ia_1[1])
                {
                    bas.Agregar_a_archivo_sin_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_ws_2[2]], contacto + G_caracter_separacion_funciones_espesificas[1] + mensage);                    
                    bas.Editar_fila_espesifica_SIN_ARREGLO_GG(G_direccion_de_banderas_transferencias, 4, (id_atras_actual_adelante_ws_2[2]) + "");
                }
                else
                {
                    bas.Agregar_a_archivo_sin_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_ws_2[1]], contacto + G_caracter_separacion_funciones_espesificas[1] + mensage);
                }


            }



        }
        public void datos_salida_y_borrado(IWebDriver manejadores, WebDriverWait esperar, string ia_ws = "ws")
        {
            int[] id_atras_actual_adelante_1 = checar_numero_de_direccion_de_archivo_atras_actual_adelante(2);//esta es de la ia
            int[] id_atras_actual_adelante_2 = checar_numero_de_direccion_de_archivo_atras_actual_adelante(5);//este es del ws

            int[] id_atras_actual_adelante_pedido_1 = checar_numero_de_direccion_de_archivo_atras_actual_adelante(3);//esta es de la ia
            int[] id_atras_actual_adelante_pedido_2 = checar_numero_de_direccion_de_archivo_atras_actual_adelante(6);//este es del ws

            if (ia_ws == "ws")//envia info de archivos respuesta y elimina la informacion
            {
                string[] respuestas_ia = bas.Leer_inicial(G_dir_arch_transferencia[id_atras_actual_adelante_2[1]]);

                if (id_atras_actual_adelante_1[1] == id_atras_actual_adelante_2[1])
                {


                    if (respuestas_ia.Length > 1)
                    {


                        for (int i = G_donde_inicia_la_tabla; i < respuestas_ia.Length; i++)
                        {
                            string[] res_espliteada = respuestas_ia[i].Split(G_caracter_separacion_funciones_espesificas[1][0]);
                            regresr_respuesta_ia(manejadores, esperar, res_espliteada[0], res_espliteada[1]);
                        }

                        bas.cambiar_archivo_con_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_2[1]], new string[] { "sin_informacion" });
                    }
                }
                else
                {

                    if (respuestas_ia.Length > 1)
                    {
                        for (int i = G_donde_inicia_la_tabla; i < respuestas_ia.Length; i++)
                        {
                            string[] res_espliteada = respuestas_ia[i].Split(G_caracter_separacion_funciones_espesificas[1][0]);
                            regresr_respuesta_ia(manejadores, esperar, res_espliteada[0], res_espliteada[1]);
                        }

                        bas.cambiar_archivo_con_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_2[1]], new string[] { "sin_informacion" });
                    }
                    bas.Editar_fila_espesifica_SIN_ARREGLO_GG(G_direccion_de_banderas_transferencias, 5, id_atras_actual_adelante_2[2] + "");
                }

                //pedidos
                string[] respuestas_ia_pedidos = bas.Leer_inicial(G_dir_arch_transferencia[id_atras_actual_adelante_pedido_2[1]]);
                if (id_atras_actual_adelante_pedido_1[1] == id_atras_actual_adelante_pedido_2[1])
                {
                    if (respuestas_ia.Length > 1)
                    {
                        for (int i = G_donde_inicia_la_tabla; i < respuestas_ia_pedidos.Length; i++)
                        {
                            string[] res_espliteada = respuestas_ia_pedidos[i].Split(G_caracter_separacion_funciones_espesificas[1][0]);
                            regresr_respuesta_ia(manejadores, esperar, res_espliteada[0], res_espliteada[1]);
                        }

                        bas.cambiar_archivo_con_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_pedido_2[1]], new string[] { "sin_informacion" });
                    }
                }
                else
                {
                    if (respuestas_ia.Length > 1)
                    {
                        for (int i = G_donde_inicia_la_tabla; i < respuestas_ia_pedidos.Length; i++)
                        {
                            string[] res_espliteada = respuestas_ia_pedidos[i].Split(G_caracter_separacion_funciones_espesificas[1][0]);
                            regresr_respuesta_ia(manejadores, esperar, res_espliteada[0], res_espliteada[1]);
                        }

                        bas.cambiar_archivo_con_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_pedido_2[1]], new string[] { "sin_informacion" });
                    }
                    bas.Editar_fila_espesifica_SIN_ARREGLO_GG(G_direccion_de_banderas_transferencias, 6, id_atras_actual_adelante_pedido_2[2] + "");

                }
                

            }

        }



        public void recargar_arreglos()
        {
            string[] chequeo = bas.Leer_inicial(G_dir_para_registros_y_configuraciones[3, 0]);
            if (chequeo.Length > G_donde_inicia_la_tabla)
            {
                if (chequeo[G_donde_inicia_la_tabla] == "1")
                {
                    for (int i = 0; i < G_dir_arch_mensages.Length; i++)
                    {
                        int indice_de_arreglo_de_arreglos = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(G_dir_arch_mensages[i]));
                        Tex_base.GG_base_arreglo_de_arreglos[indice_de_arreglo_de_arreglos] = bas.Leer_inicial(G_dir_arch_mensages[i]);
                    }

                }
            }


        }


    }

}