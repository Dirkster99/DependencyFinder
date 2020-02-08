﻿using DependencyFinder.Core;
using DependencyFinder.Core.Models;
using System.Threading.Tasks;

namespace DependencyFinder.UI.Models
{
    public class TypesCollectionViewModel : TreeViewItemViewModel
    {
        private readonly ISolutionManager _solutionManager;
        private readonly string _projectPath;
        private readonly string _solutionPath;

        public TypesCollectionViewModel(TreeViewItemViewModel parent, string projectName, string solutionPath, ISolutionManager solutionManager) : base(parent, true)
        {
            Name = $"Types";
            _solutionManager = solutionManager;
            _projectPath = projectName;
            _solutionPath = solutionPath;
        }

        protected override void LoadChildren()
        {
            Children.Add(TypeViewModel.Empty(this));

            Task.Run(() => _solutionManager.GetProjectTypes(_projectPath, _solutionPath)).ContinueWith((result) =>
            {
                Children.Clear();

                foreach (var type in result.Result)
                {
                    if(type is InterfaceDetails id)
                    {
                        Children.Add(new InterfaceViewModel(id, this));
                    }
                    else if (type is ClassDetails cd)
                    {
                        Children.Add(new ClassViewModel(cd, this));
                    }
                    else if (type is EnumDetails ed)
                    {
                        Children.Add(new EnumViewModel(ed, this));
                    }
                    else if (type is StructDetails sd)
                    {
                        Children.Add(new StructViewModel(sd, this));
                    }

                }
            }, TaskScheduler.FromCurrentSynchronizationContext());

            base.LoadChildren();
        }
    }
}