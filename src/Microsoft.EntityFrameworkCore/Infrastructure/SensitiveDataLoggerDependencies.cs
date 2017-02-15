// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.Extensions.Logging;

namespace Microsoft.EntityFrameworkCore.Infrastructure
{
    /// <summary>
    ///     <para>
    ///         Service dependencies parameter class for <see cref="SensitiveDataLogger{T}" />
    ///     </para>
    ///     <para>
    ///         This type is typically used by database providers (and other extensions). It is generally
    ///         not used in application code.
    ///     </para>
    /// </summary>
    public sealed class SensitiveDataLoggerDependencies<T>
    {
        /// <summary>
        ///     <para>
        ///         Creates the service dependencies parameter object for a <see cref="SensitiveDataLogger{T}" />.
        ///     </para>
        ///     <para>
        ///         This type is typically used by database providers (and other extensions). It is generally
        ///         not used in application code.
        ///     </para>
        ///     <para>
        ///         Do not call this constructor directly from provider or application code as it may change
        ///         as new dependencies are added. Use the 'With...' methods instead.
        ///     </para>
        /// </summary>
        /// <param name="logger">
        ///     The underlying logger to which logging information should be written.
        /// </param>
        /// <param name="contextOptions">
        ///     The options for the context that this logger is being used with.
        /// </param>
        public SensitiveDataLoggerDependencies(
            [NotNull] ILogger<T> logger,
            [CanBeNull] IDbContextOptions contextOptions)
        {
            Check.NotNull(logger, nameof(logger));

            Logger = logger;
            ContextOptions = contextOptions;
        }

        /// <summary>
        ///     The underlying logger to which logging information should be written.
        /// </summary>
        public ILogger<T> Logger { get; }

        /// <summary>
        ///     The options for the context that this logger is being used with.
        /// </summary>
        public IDbContextOptions ContextOptions { get; }
    }
}
