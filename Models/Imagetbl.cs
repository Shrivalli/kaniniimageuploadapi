using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace imageuploadapi.Models;

public partial class Imagetbl
{
    public int Imgid { get; set; }

    public string? Imgname { get; set; }

    
}
