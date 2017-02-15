// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Utilities;

namespace Microsoft.EntityFrameworkCore.Query.ExpressionVisitors
{
    /// <summary>
    ///     <para>
    ///         Service dependencies parameter class for <see cref="SqlTranslatingExpressionVisitor" />
    ///     </para>
    ///     <para>
    ///         This type is typically used by database providers (and other extensions). It is generally
    ///         not used in application code.
    ///     </para>
    /// </summary>
    public sealed class SqlTranslatingExpressionVisitorDependencies
    {
        /// <summary>
        ///     <para>
        ///         Creates the service dependencies parameter object for a <see cref="SqlTranslatingExpressionVisitor" />.
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
        /// <param name="relationalAnnotationProvider"> The relational annotation provider. </param>
        /// <param name="compositeExpressionFragmentTranslator"> The composite expression fragment translator. </param>
        /// <param name="methodCallTranslator"> The method call translator. </param>
        /// <param name="memberTranslator"> The member translator. </param>
        /// <param name="relationalTypeMapper"> The relational type mapper. </param>
        public SqlTranslatingExpressionVisitorDependencies(
            [NotNull] IRelationalAnnotationProvider relationalAnnotationProvider,
            [NotNull] IExpressionFragmentTranslator compositeExpressionFragmentTranslator,
            [NotNull] IMethodCallTranslator methodCallTranslator,
            [NotNull] IMemberTranslator memberTranslator,
            [NotNull] IRelationalTypeMapper relationalTypeMapper)
        {
            Check.NotNull(relationalAnnotationProvider, nameof(relationalAnnotationProvider));
            Check.NotNull(compositeExpressionFragmentTranslator, nameof(compositeExpressionFragmentTranslator));
            Check.NotNull(methodCallTranslator, nameof(methodCallTranslator));
            Check.NotNull(memberTranslator, nameof(memberTranslator));
            Check.NotNull(relationalTypeMapper, nameof(relationalTypeMapper));

            RelationalAnnotationProvider = relationalAnnotationProvider;
            CompositeExpressionFragmentTranslator = compositeExpressionFragmentTranslator;
            MethodCallTranslator = methodCallTranslator;
            MemberTranslator = memberTranslator;
            RelationalTypeMapper = relationalTypeMapper;
        }

        /// <summary>
        ///     The relational annotation provider.
        /// </summary>
        public IRelationalAnnotationProvider RelationalAnnotationProvider { get; }

        /// <summary>
        ///     The composite expression fragment translator.
        /// </summary>
        public IExpressionFragmentTranslator CompositeExpressionFragmentTranslator { get; }

        /// <summary>
        ///     The method call translator.
        /// </summary>
        public IMethodCallTranslator MethodCallTranslator { get; }

        /// <summary>
        ///     The member translator.
        /// </summary>
        public IMemberTranslator MemberTranslator { get; }

        /// <summary>
        ///     The relational type mapper.
        /// </summary>
        public IRelationalTypeMapper RelationalTypeMapper { get; }
    }
}
