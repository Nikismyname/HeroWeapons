//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebFormsWithDbFirst.HeroModelDesigner
{
    using System;
    using System.Collections.Generic;
    
    public partial class HeroWeapon
    {
        public int HeroId { get; set; }
        public int WeaponId { get; set; }
        public int BondStregth { get; set; }
    
        public virtual Hero Hero { get; set; }
        public virtual Weapon Weapon { get; set; }
    }
}
