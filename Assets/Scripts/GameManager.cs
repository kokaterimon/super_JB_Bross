﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Posibles estados de videojuego
public enum GameState
{
    menu,
    inGame,
    gamerOver
}

public class GameManager : MonoBehaviour {

    //Variable que referencia al propio Game Manager
    public static GameManager sharedInstance;

    //Variable para saber en qué estado del juego nos encontramos ahora mismo
    //Al inicio, queremos que empieceen el menú principal
    public GameState currentGameState = GameState.menu;

    private void Awake(){
        sharedInstance = this;
    }

    private void Start()
    {
        BackToMenu();
    }
 
    private void Update(){
        if (Input.GetButtonDown("Start") && this.currentGameState != GameState.inGame){
            StartGame();
        }

        if (Input.GetButtonDown("Pause")){
            BackToMenu();
        }   
    }

    //Método encargado deiniciar el juego
    public void StartGame(){
        SetGameState(GameState.inGame);
        PlayerController.sharedInstance.StartGame();
    }

    //Método que se llamará cuando el jugador muera
    public void GameOver(){
        SetGameState(GameState.gamerOver);
    }

    //Método para volver al menú principal cuando el usuario lo quiera hacer
    public void BackToMenu(){
        SetGameState(GameState.gamerOver);        
    }

    //Método encargado de cambiar el estado del juego
    void SetGameState(GameState newGameState){
        if (newGameState == GameState.menu){
            //Hay que preparar la escena de Unity para mostrar el menú
        }
        else if (newGameState == GameState.inGame){
            //Hay que preparar la escena de Unity para jugar

        }
        else if (newGameState == GameState.gamerOver){
            //Hay que preparar la escena de Unity para el Game Over

        }

        //Asignamos el estado de juego actual al que nos ha llegado por parámetro
        this.currentGameState = newGameState;
    }
}
