﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace userVoice.DTo
{
    public class UpdateEmailDTO
    {
        [Required]
        public String Email { get; set;  }
    }
}
