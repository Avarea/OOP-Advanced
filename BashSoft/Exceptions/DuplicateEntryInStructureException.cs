﻿using System;

namespace BashSoft.Exceptions
{
    internal class DuplicateEntryInStructureException : Exception
    {
        private const string DublicateEntry = "The {0} already exists in {1}.";

        public DuplicateEntryInStructureException() : base(DublicateEntry)
        {
        }

        public DuplicateEntryInStructureException(string entry, string structure) : base(string.Format(DublicateEntry, entry, structure))
        {
        }
    }
}
