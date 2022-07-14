// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Internal;

namespace Microsoft.AspNetCore.Mvc.Infrastructure;

// REVIEW: Should this be public API?
internal class ControllerEndpointFilterInvocationContext : EndpointFilterInvocationContext
{
    public ControllerEndpointFilterInvocationContext(
        ActionContext actionContext,
        ObjectMethodExecutor executor,
        IActionResultTypeMapper mapper,
        object controller,
        object?[]? arguments)
    {
        ActionContext = actionContext;
        Mapper = mapper;
        Executor = executor;
        Controller = controller;
        Arguments = arguments ?? Array.Empty<object?>();
    }

    public object Controller { get; }

    internal IActionResultTypeMapper Mapper { get; }

    internal ActionContext ActionContext { get; }

    internal ObjectMethodExecutor Executor { get; }

    public override HttpContext HttpContext => ActionContext.HttpContext;

    public override IList<object?> Arguments { get; }

    public override T GetArgument<T>(int index)
    {
        return (T)Arguments[index]!;
    }
}
