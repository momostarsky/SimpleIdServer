﻿using FormBuilder.Factories;
using System.Text.Json.Nodes;

namespace FormBuilder.Rules;

public class PropertyTransformationRuleEngine : GenericTransformationRule<PropertyTransformationRule>
{
    private readonly IConditionRuleEngineFactory _conditionRuleEngineFactory;

    public PropertyTransformationRuleEngine(IConditionRuleEngineFactory conditionRuleEngineFactory)
    {
        _conditionRuleEngineFactory = conditionRuleEngineFactory;
    }

    public override string Type => PropertyTransformationRule.TYPE;

    protected override void ProtectedApply<R>(R record, JsonObject input, PropertyTransformationRule parameter)
    {
        if(parameter.Condition != null)
        {
            if (!_conditionRuleEngineFactory.Evaluate(input, parameter.Condition)) return;
        }

        var type = record.GetType();
        var property = type.GetProperty(parameter.PropertyName);
        if (property.PropertyType.IsEnum) property.SetValue(record, Enum.Parse(property.PropertyType, parameter.PropertyValue));
        else property.SetValue(record, Convert.ChangeType(parameter.PropertyValue, property.PropertyType));
    }
}