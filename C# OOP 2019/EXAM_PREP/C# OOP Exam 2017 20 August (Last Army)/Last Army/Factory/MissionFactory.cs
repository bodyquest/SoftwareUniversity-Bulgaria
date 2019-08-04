﻿using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        var type = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == difficultyLevel);

        return (IMission)Activator.CreateInstance(type, neededPoints);
    }
}

