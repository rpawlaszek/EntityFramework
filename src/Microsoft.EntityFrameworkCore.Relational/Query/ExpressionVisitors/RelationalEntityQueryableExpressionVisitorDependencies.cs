// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Utilities;

namespace Microsoft.EntityFrameworkCore.Query.ExpressionVisitors
{
    /// <summary>
    ///     <para>
    ///         Service dependencies parameter class for <see cref="RelationalQueryCompilationContext" />
    ///     </para>
    ///     <para>
    ///         This type is typically used by database providers (and other extensions). It is generally
    ///         not used in application code.
    ///     </para>
    /// </summary>
    public sealed class RelationalEntityQueryableExpressionVisitorDependencies
    {
        /// <summary>
        ///     <para>
        ///         Creates the service dependencies parameter object for a
        ///         <see cref="RelationalEntityQueryableExpressionVisitorFactory" />.
        ///     </para>
        ///     <para>
        ///         Do not call this constructor directly from provider or application code as it may change
        ///         as new dependencies are added. Use the 'With...' methods instead.
        ///     </para>
        /// </summary>
        /// <param name="model"> The model. </param>
        /// <param name="selectExpressionFactory"> The select expression factory. </param>
        /// <param name="materializerFactory"> The materializer factory. </param>
        /// <param name="shaperCommandContextFactory"> The shaper command context factory. </param>
        /// <param name="relationalAnnotationProvider"> The relational annotation provider. </param>
        public RelationalEntityQueryableExpressionVisitorDependencies(
            [NotNull] IModel model,
            [NotNull] ISelectExpressionFactory selectExpressionFactory,
            [NotNull] IMaterializerFactory materializerFactory,
            [NotNull] IShaperCommandContextFactory shaperCommandContextFactory,
            [NotNull] IRelationalAnnotationProvider relationalAnnotationProvider)
        {
            Check.NotNull(model, nameof(model));
            Check.NotNull(selectExpressionFactory, nameof(selectExpressionFactory));
            Check.NotNull(materializerFactory, nameof(materializerFactory));
            Check.NotNull(shaperCommandContextFactory, nameof(shaperCommandContextFactory));
            Check.NotNull(relationalAnnotationProvider, nameof(relationalAnnotationProvider));

            Model = model;
            SelectExpressionFactory = selectExpressionFactory;
            MaterializerFactory = materializerFactory;
            ShaperCommandContextFactory = shaperCommandContextFactory;
            RelationalAnnotationProvider = relationalAnnotationProvider;
        }

        /// <summary>
        ///     The model.
        /// </summary>
        public IModel Model { get; }

        /// <summary>
        ///     The select expression factory.
        /// </summary>
        public ISelectExpressionFactory SelectExpressionFactory { get; }

        /// <summary>
        ///     The materializer factory.
        /// </summary>
        public IMaterializerFactory MaterializerFactory { get; }

        /// <summary>
        ///     The shaper command context factory.
        /// </summary>
        public IShaperCommandContextFactory ShaperCommandContextFactory { get; }

        /// <summary>
        ///     The relational annotation provider.
        /// </summary>
        public IRelationalAnnotationProvider RelationalAnnotationProvider { get; }
    }
}
