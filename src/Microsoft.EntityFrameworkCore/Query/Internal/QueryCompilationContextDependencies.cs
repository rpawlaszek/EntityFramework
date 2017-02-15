// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using Microsoft.EntityFrameworkCore.Utilities;

namespace Microsoft.EntityFrameworkCore.Query.Internal
{
    /// <summary>
    ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public sealed class QueryCompilationContextDependencies
    {
        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public QueryCompilationContextDependencies(
            [NotNull] IModel model,
            [NotNull] ISensitiveDataLogger<IQueryCompilationContextFactory> logger,
            [NotNull] IEntityQueryModelVisitorFactory entityQueryModelVisitorFactory,
            [NotNull] IRequiresMaterializationExpressionVisitorFactory requiresMaterializationExpressionVisitorFactory,
            [NotNull] ICurrentDbContext currentContext)
        {
            Check.NotNull(model, nameof(model));
            Check.NotNull(logger, nameof(logger));
            Check.NotNull(entityQueryModelVisitorFactory, nameof(entityQueryModelVisitorFactory));
            Check.NotNull(requiresMaterializationExpressionVisitorFactory, nameof(requiresMaterializationExpressionVisitorFactory));
            Check.NotNull(currentContext, nameof(currentContext));

            Model = model;
            Logger = logger;
            EntityQueryModelVisitorFactory = entityQueryModelVisitorFactory;
            RequiresMaterializationExpressionVisitorFactory = requiresMaterializationExpressionVisitorFactory;
            CurrentContext = currentContext;
        }

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IModel Model { get; }

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public ISensitiveDataLogger<IQueryCompilationContextFactory> Logger { get; }

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IEntityQueryModelVisitorFactory EntityQueryModelVisitorFactory { get; }

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IRequiresMaterializationExpressionVisitorFactory RequiresMaterializationExpressionVisitorFactory { get; }

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public ICurrentDbContext CurrentContext { get; }

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public QueryCompilationContextDependencies With([NotNull] IModel model)
            => new QueryCompilationContextDependencies(
                Check.NotNull(model, nameof(model)),
                Logger,
                EntityQueryModelVisitorFactory,
                RequiresMaterializationExpressionVisitorFactory,
                CurrentContext);

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public QueryCompilationContextDependencies With([NotNull] ISensitiveDataLogger<IQueryCompilationContextFactory> logger) => new QueryCompilationContextDependencies(
            Model,
            Check.NotNull(logger, nameof(logger)),
            EntityQueryModelVisitorFactory,
            RequiresMaterializationExpressionVisitorFactory,
            CurrentContext);

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public QueryCompilationContextDependencies With([NotNull] IEntityQueryModelVisitorFactory entityQueryModelVisitorFactory) => new QueryCompilationContextDependencies(
            Model,
            Logger,
            Check.NotNull(entityQueryModelVisitorFactory, nameof(entityQueryModelVisitorFactory)),
            RequiresMaterializationExpressionVisitorFactory,
            CurrentContext);

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public QueryCompilationContextDependencies With(
            [NotNull] IRequiresMaterializationExpressionVisitorFactory requiresMaterializationExpressionVisitorFactory) => new QueryCompilationContextDependencies(
            Model,
            Logger,
            EntityQueryModelVisitorFactory,
            Check.NotNull(requiresMaterializationExpressionVisitorFactory, nameof(requiresMaterializationExpressionVisitorFactory)),
            CurrentContext);

        /// <summary>
        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public QueryCompilationContextDependencies With([NotNull] ICurrentDbContext currentContext) => new QueryCompilationContextDependencies(
            Model,
            Logger,
            EntityQueryModelVisitorFactory,
            RequiresMaterializationExpressionVisitorFactory,
            Check.NotNull(currentContext, nameof(currentContext)));
    }
}
