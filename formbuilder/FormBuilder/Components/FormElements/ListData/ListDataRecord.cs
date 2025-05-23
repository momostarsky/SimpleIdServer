﻿using FormBuilder.Models;
using FormBuilder.Models.Rules;
using System.Collections.ObjectModel;

namespace FormBuilder.Components.FormElements.ListData;

public class ListDataRecord : BaseFormDataRecord
{
    public override string Type => ListDataDefinition.TYPE;
    public IRepetitionRule RepetitionRule { get; set; }
    public List<IFormElementRecord> Children { get; set; }
    internal ObservableCollection<IFormElementRecord> Elements { get; set; }
}