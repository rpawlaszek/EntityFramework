// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Utilities;

namespace Microsoft.EntityFrameworkCore.Query
{
    /// <summary>
    ///     <para>
    ///         Service dependencies parameter class for <see cref="EntityQueryModelVisitor" />
    ///     </para>
    ///     <para>
    ///         This type is typically used by database providers (and other extensions). It is generally
    ///         not used in application code.
    ///     </para>
    /// </summary>
    public sealed class EntityQueryModelVisitorDependencies
    {
        /// <summary>
        ///     <para>
        ///         Creates the service dependencies parameter object for a <see cref="EntityQueryModelVisitorFactory" />.
        ///     </para>
        ///     <para>
        ///         This API supports the Entity Framework Core infrastructure and is not intended to be used
        ///         directly from your code. This API may change or be removed in future releases.
        ///     </para>
        ///     <para>
        ///         Do not call this constructor directly from provider or application code as it may change
        ///         as new dependencies are added. Use the 'With...' methods instead.
        ///     </para>
        /// </summary>
        /// <param name="queryOptimizer"> The <see cref="IQueryOptimizer" /> to be used when processing the query. </param>
        /// <param name="navigationRewritingExpressionVisitorFactory">
        ///     The <see cref="INavigationRewritingExpressionVisitorFactory" /> to be used when
        ///     processing the query.
        /// </param>
        /// <param name="subQueryMemberPushDownExpressionVisitor">
        ///     The <see cref="ISubQueryMemberPushDownExpressionVisitor" /> to be used when
        ///     processing the query.
        /// </param>
        /// <param name="querySourceTracingExpressionVisitorFactory">
        ///     The <see cref="IQuerySourceTracingExpressionVisitorFactory" /> to be used when
        ///     processing the query.
        /// </param>
        /// <param name="entityResultFindingExpressionVisitorFactory">
        ///     The <see cref="IEntityResultFindingExpressionVisitorFactory" /> to be used when
        ///     processing the query.
        /// </param>
        /// <param name="taskBlockingExpressionVisitor"> The <see cref="ITaskBlockingExpressionVisitor" /> to be used when processing the query. </param>
        /// <param name="memberAccessBindingExpressionVisitorFactory">
        ///     The <see cref="IMemberAccessBindingExpressionVisitorFactory" /> to be used when
        ///     processing the query.
        /// </param>
        /// <param name="orderingExpressionVisitorFactory"> The <see cref="IOrderingExpressionVisitorFactory" /> to be used when processing the query. </param>
        /// <param name="projectionExpressionVisitorFactory">
        ///     The <see cref="IProjectionExpressionVisitorFactory" /> to be used when processing the
        ///     query.
        /// </param>
        /// <param name="entityQueryableExpressionVisitorFactory">
        ///     The <see cref="IEntityQueryableExpressionVisitorFactory" /> to be used when
        ///     processing the query.
        /// </param>
        /// <param name="queryAnnotationExtractor"> The <see cref="IQueryAnnotationExtractor" /> to be used when processing the query. </param>
        /// <param name="resultOperatorHandler"> The <see cref="IResultOperatorHandler" /> to be used when processing the query. </param>
        /// <param name="entityMaterializerSource"> The <see cref="IEntityMaterializerSource" /> to be used when processing the query. </param>
        /// <param name="expressionPrinter"> The <see cref="IExpressionPrinter" /> to be used when processing the query. </param>
        public EntityQueryModelVisitorDependencies(
            [NotNull] IQueryOptimizer queryOptimizer,
            [NotNull] INavigationRewritingExpressionVisitorFactory navigationRewritingExpressionVisitorFactory,
            [NotNull] ISubQueryMemberPushDownExpressionVisitor subQueryMemberPushDownExpressionVisitor,
            [NotNull] IQuerySourceTracingExpressionVisitorFactory querySourceTracingExpressionVisitorFactory,
            [NotNull] IEntityResultFindingExpressionVisitorFactory entityResultFindingExpressionVisitorFactory,
            [NotNull] ITaskBlockingExpressionVisitor taskBlockingExpressionVisitor,
            [NotNull] IMemberAccessBindingExpressionVisitorFactory memberAccessBindingExpressionVisitorFactory,
            [NotNull] IOrderingExpressionVisitorFactory orderingExpressionVisitorFactory,
            [NotNull] IProjectionExpressionVisitorFactory projectionExpressionVisitorFactory,
            [NotNull] IEntityQueryableExpressionVisitorFactory entityQueryableExpressionVisitorFactory,
            [NotNull] IQueryAnnotationExtractor queryAnnotationExtractor,
            [NotNull] IResultOperatorHandler resultOperatorHandler,
            [NotNull] IEntityMaterializerSource entityMaterializerSource,
            [NotNull] IExpressionPrinter expressionPrinter)
        {
            Check.NotNull(queryOptimizer, nameof(queryOptimizer));
            Check.NotNull(navigationRewritingExpressionVisitorFactory, nameof(navigationRewritingExpressionVisitorFactory));
            Check.NotNull(subQueryMemberPushDownExpressionVisitor, nameof(subQueryMemberPushDownExpressionVisitor));
            Check.NotNull(querySourceTracingExpressionVisitorFactory, nameof(querySourceTracingExpressionVisitorFactory));
            Check.NotNull(entityResultFindingExpressionVisitorFactory, nameof(entityResultFindingExpressionVisitorFactory));
            Check.NotNull(taskBlockingExpressionVisitor, nameof(taskBlockingExpressionVisitor));
            Check.NotNull(memberAccessBindingExpressionVisitorFactory, nameof(memberAccessBindingExpressionVisitorFactory));
            Check.NotNull(orderingExpressionVisitorFactory, nameof(orderingExpressionVisitorFactory));
            Check.NotNull(projectionExpressionVisitorFactory, nameof(projectionExpressionVisitorFactory));
            Check.NotNull(entityQueryableExpressionVisitorFactory, nameof(entityQueryableExpressionVisitorFactory));
            Check.NotNull(queryAnnotationExtractor, nameof(queryAnnotationExtractor));
            Check.NotNull(resultOperatorHandler, nameof(resultOperatorHandler));
            Check.NotNull(entityMaterializerSource, nameof(entityMaterializerSource));
            Check.NotNull(expressionPrinter, nameof(expressionPrinter));

            QueryOptimizer = queryOptimizer;
            NavigationRewritingExpressionVisitorFactory = navigationRewritingExpressionVisitorFactory;
            SubQueryMemberPushDownExpressionVisitor = subQueryMemberPushDownExpressionVisitor;
            QuerySourceTracingExpressionVisitorFactory = querySourceTracingExpressionVisitorFactory;
            EntityResultFindingExpressionVisitorFactory = entityResultFindingExpressionVisitorFactory;
            TaskBlockingExpressionVisitor = taskBlockingExpressionVisitor;
            MemberAccessBindingExpressionVisitorFactory = memberAccessBindingExpressionVisitorFactory;
            OrderingExpressionVisitorFactory = orderingExpressionVisitorFactory;
            ProjectionExpressionVisitorFactory = projectionExpressionVisitorFactory;
            EntityQueryableExpressionVisitorFactory = entityQueryableExpressionVisitorFactory;
            QueryAnnotationExtractor = queryAnnotationExtractor;
            ResultOperatorHandler = resultOperatorHandler;
            EntityMaterializerSource = entityMaterializerSource;
            ExpressionPrinter = expressionPrinter;
        }

        /// <summary>
        ///     Gets the <see cref="IQueryOptimizer" /> to be used when processing a query.
        /// </summary>
        public IQueryOptimizer QueryOptimizer { get; }

        /// <summary>
        ///     Gets the <see cref="INavigationRewritingExpressionVisitorFactory" /> to be used when processing a query.
        /// </summary>
        public INavigationRewritingExpressionVisitorFactory NavigationRewritingExpressionVisitorFactory { get; }

        /// <summary>
        ///     Gets the <see cref="ISubQueryMemberPushDownExpressionVisitor" /> to be used when processing a query.
        /// </summary>
        public ISubQueryMemberPushDownExpressionVisitor SubQueryMemberPushDownExpressionVisitor { get; }

        /// <summary>
        ///     Gets the <see cref="IQuerySourceTracingExpressionVisitorFactory" /> to be used when processing a query.
        /// </summary>
        public IQuerySourceTracingExpressionVisitorFactory QuerySourceTracingExpressionVisitorFactory { get; }

        /// <summary>
        ///     Gets the <see cref="IEntityResultFindingExpressionVisitorFactory" /> to be used when processing a query.
        /// </summary>
        public IEntityResultFindingExpressionVisitorFactory EntityResultFindingExpressionVisitorFactory { get; }

        /// <summary>
        ///     Gets the <see cref="ITaskBlockingExpressionVisitor" /> to be used when processing a query.
        /// </summary>
        public ITaskBlockingExpressionVisitor TaskBlockingExpressionVisitor { get; }

        /// <summary>
        ///     Gets the <see cref="IMemberAccessBindingExpressionVisitorFactory" /> to be used when processing a query.
        /// </summary>
        public IMemberAccessBindingExpressionVisitorFactory MemberAccessBindingExpressionVisitorFactory { get; }

        /// <summary>
        ///     Gets the <see cref="IOrderingExpressionVisitorFactory" /> to be used when processing a query.
        /// </summary>
        public IOrderingExpressionVisitorFactory OrderingExpressionVisitorFactory { get; }

        /// <summary>
        ///     Gets the <see cref="IProjectionExpressionVisitorFactory" /> to be used when processing a query.
        /// </summary>
        public IProjectionExpressionVisitorFactory ProjectionExpressionVisitorFactory { get; }

        /// <summary>
        ///     Gets the <see cref="IEntityQueryableExpressionVisitorFactory" /> to be used when processing a query.
        /// </summary>
        public IEntityQueryableExpressionVisitorFactory EntityQueryableExpressionVisitorFactory { get; }

        /// <summary>
        ///     Gets the <see cref="IExpressionPrinter" /> to be used when processing a query.
        /// </summary>
        public IExpressionPrinter ExpressionPrinter { get; }

        /// <summary>
        ///     Gets the <see cref="IEntityMaterializerSource" /> to be used when processing a query.
        /// </summary>
        public IEntityMaterializerSource EntityMaterializerSource { get; }

        /// <summary>
        ///     Gets the <see cref="IResultOperatorHandler" /> to be used when processing a query.
        /// </summary>
        public IResultOperatorHandler ResultOperatorHandler { get; }

        /// <summary>
        ///     Gets the <see cref="IQueryAnnotationExtractor" /> to be used when processing a query.
        /// </summary>
        public IQueryAnnotationExtractor QueryAnnotationExtractor { get; }

        /// <summary>
        ///     Clones this dependency parameter object with one service replaced.
        /// </summary>
        /// <param name="resultOperatorHandler">
        ///     A replacement for the current dependency of this type.
        /// </param>
        /// <returns> A new parameter object with the given service replaced. </returns>
        public EntityQueryModelVisitorDependencies With([NotNull] IResultOperatorHandler resultOperatorHandler)
            => new EntityQueryModelVisitorDependencies(
                QueryOptimizer,
                NavigationRewritingExpressionVisitorFactory,
                SubQueryMemberPushDownExpressionVisitor,
                QuerySourceTracingExpressionVisitorFactory,
                EntityResultFindingExpressionVisitorFactory,
                TaskBlockingExpressionVisitor,
                MemberAccessBindingExpressionVisitorFactory,
                OrderingExpressionVisitorFactory,
                ProjectionExpressionVisitorFactory,
                EntityQueryableExpressionVisitorFactory,
                QueryAnnotationExtractor,
                Check.NotNull(resultOperatorHandler, nameof(resultOperatorHandler)),
                EntityMaterializerSource,
                ExpressionPrinter);
    }
}
