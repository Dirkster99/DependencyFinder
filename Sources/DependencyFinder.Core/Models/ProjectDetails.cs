﻿using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace DependencyFinder.Core.Models
{
    public class ProjectDetails : ValueObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RelativePath { get; set; }
        public string AbsolutePath { get; set; }
        public string Type { get; set; }
        public string Solution { get; set; }
        public bool IsNetCore { get; set; }
        public bool IsMultiTarget { get; set; }
        public AssemblyInfo AssemblyInfo { get; set; }

        public List<NugetPackage> Nugets { get; set; } = new List<NugetPackage>();
        public List<ProjectReference> ProjectReferences { get; set; } = new List<ProjectReference>();
        public List<ProjectTarget> ProjectTargets { get; set; } = new List<ProjectTarget>();
        public List<ProjectReference> DirectReferences { get; set; } = new List<ProjectReference>();

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}