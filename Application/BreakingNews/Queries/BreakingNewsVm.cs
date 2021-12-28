using System;
using System.Collections.Generic;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.BreakingNews.Queries
{
    public class BreakingNewsVm
    {
        public string Id { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public string TimeCreated { get; set; }
        public string LastTimeUpdated { get; set; }
    }
}