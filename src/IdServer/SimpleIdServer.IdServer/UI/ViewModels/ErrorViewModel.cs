﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using SimpleIdServer.IdServer.Domains;
using System.Collections.Generic;

namespace SimpleIdServer.IdServer.UI.ViewModels;

public class ErrorViewModel : ILayoutViewModel
{
    public ErrorViewModel(string code, string message, List<Language> languages)
    {
        Code = code;
        Message = message;
        Languages = languages;
    }

    public string Code { get; }
    public string Message { get; }
    public List<Language> Languages { get; set; }
}
