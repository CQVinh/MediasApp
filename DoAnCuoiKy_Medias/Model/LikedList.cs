//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnCuoiKy_Medias.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class LikedList
    {
        public int Id { get; set; }
        public Nullable<int> ProfileId { get; set; }
        public Nullable<int> MoviesId { get; set; }
    
        public virtual Movies Movies { get; set; }
        public virtual Profiles Profiles { get; set; }
    }
}
