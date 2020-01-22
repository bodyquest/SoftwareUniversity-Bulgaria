﻿namespace IRunes.Models
{
    using System;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;

    public class Album
    {
        public Album()
        {
            this.Tracks = new List<Track>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public List<Track> Tracks { get; set; }
    }
}
