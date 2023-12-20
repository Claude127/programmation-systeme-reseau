using System;
using System.Collections.Generic;
using System.IO;
using projetResto.controller;

namespace projetResto.model;

public  static class Parameters
{
public const int TABLES_BY_SQUARE = 6;
public const int SERVER_BY_SQUARE = 1;
public const int RANKCHIEF_NUMBER = 2;
public static int MAP_NUMBER = Int32.Parse(ParametersController.GetValueOrDefault("MAP_NUMBER", "40"));
public static int SPEED = Int32.Parse(ParametersController.GetValueOrDefault("SPEED", "1"));

public static string KICHEN_SERVER_LOCAL_IP = ParametersController.GetValueOrDefault("KICHEN_SERVER_LOCAL_IP", "127.0.0.1");
public static int KITCHEN_SERVER_COMMAND_PORT = Int32.Parse(ParametersController.GetValueOrDefault("KITCHEN_SERVER_COMMAND_PORT", "9897"));
public static bool KITCHEN_SERVER_STARTED = false;

public static string SALLE_CLIENT_LOCAL_IP = ParametersController.GetValueOrDefault("SALLE_CLIENT_LOCAL_IP", "127.0.0.1");
public static int SALLE_CLIENT_COMMAND_PORT = Int32.Parse(ParametersController.GetValueOrDefault("SALLE_CLIENT_COMMAND_PORT", "9897"));
public static bool SALLE_CLIENT_STARTED = false;

public static int SALLE_NUMBER = 1;

public static string LOG_PATH = Directory.GetCurrentDirectory() + "\\Log.txt";

private static Dictionary<string, int> options;

public static Dictionary<string, int> Options { get => options; set => options = value; }

}