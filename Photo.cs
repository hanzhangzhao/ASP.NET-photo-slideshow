using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Photo
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Url { get; private set; }
    public string Description { get; private set; }

    public Photo(int id, string name, string url, string desc)
    {
        Id = id;
        Name = name;
        Url = url;
        Description = desc;
    }
}

