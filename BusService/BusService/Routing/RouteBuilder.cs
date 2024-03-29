﻿using System.Runtime.InteropServices;

namespace BusService.Routing
{
    public static class SubjectBuilder
    {
        private static readonly string SEPARATOR = ".";
        private static readonly string WILDCARD_ANY = "*";
        private static readonly string WILDCARD_ANY_TAIL = ">";

        public static string Build(string Topic, [Optional] string Event) => Topic + SEPARATOR + (Event ?? WILDCARD_ANY);
        public static string GetEventName(string Source) => Source.Split(SEPARATOR).Last();
    }
}
