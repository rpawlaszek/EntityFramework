// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;

namespace Microsoft.EntityFrameworkCore.Query
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
    public sealed class RelationalQueryCompilationContextDependencies
    {
        /// <summary>
        ///     <para>
        ///         Creates the service dependencies parameter object for a <see cref="RelationalQueryCompilationContext" />.
        ///     </para>
        ///     <para>
        ///         Do not call this constructor directly from provider or application code as it may change
        ///         as new dependencies are added. Use the 'With...' methods instead.
        ///     </para>
        /// </summary>
        /// <param name="nodeTypeProviderFactory"> The node type provider factory. </param>
        public RelationalQueryCompilationContextDependencies(
            [NotNull] INodeTypeProviderFactory nodeTypeProviderFactory)
        {
            Check.NotNull(nodeTypeProviderFactory, nameof(nodeTypeProviderFactory));

            NodeTypeProviderFactory = nodeTypeProviderFactory;
        }

        /// <summary>
        ///     The node type provider factory.
        /// </summary>
        public INodeTypeProviderFactory NodeTypeProviderFactory { get; }

        /// <summary>
        ///     Clones this dependency parameter object with one service replaced.
        /// </summary>
        /// <param name="nodeTypeProviderFactory">
        ///     A replacement for the current dependency of this type.
        /// </param>
        /// <returns> A new parameter object with the given service replaced. </returns>
        public RelationalQueryCompilationContextDependencies With(
            [NotNull] INodeTypeProviderFactory nodeTypeProviderFactory)
            => new RelationalQueryCompilationContextDependencies(Check.NotNull(nodeTypeProviderFactory, nameof(nodeTypeProviderFactory)));
    }
}
