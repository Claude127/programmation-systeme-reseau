using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetResto.controller;

public class ParametersController

{
    public static string GetValueOrDefault(string key, string defaultValue, bool numericalValue = false)
    {
        if (numericalValue == true)
        {
            string value = ConfigurationManager.AppSettings[key];
            if(int.TryParse(value, out int result))
                return value;
            else
                return defaultValue;
        }
        return ConfigurationManager.AppSettings[key] ?? defaultValue;
            
    }
    
}