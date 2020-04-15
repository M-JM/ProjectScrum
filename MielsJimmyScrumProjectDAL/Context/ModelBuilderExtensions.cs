
using Microsoft.EntityFrameworkCore;
using MielsJimmyScrumProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MielsJimmyScrumProjectDAL.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BoardUser>()
        .HasKey(c => new { c.BoardId, c.ApplicationUserId});
        }
    }
}
