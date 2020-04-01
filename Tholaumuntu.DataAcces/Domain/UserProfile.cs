﻿using System;

namespace Tholaumuntu.DataAcces.Domain
{
    public class UserProfile : Entity
    {
        public virtual User User { get; set; }
        public LoveLanguage LoveLanguage { get; set; }
        public string Horoscope { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public string PersonalityType { get; set; }
        public Byte[] ProfilePicture { get; set; }
        public string Gender { get; set; }
    }
    
}