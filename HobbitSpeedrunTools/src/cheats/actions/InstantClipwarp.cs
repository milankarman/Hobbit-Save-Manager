﻿using Memory;

namespace HobbitSpeedrunTools
{
    public class InstantClipwarp : ActionCheat
    {
        public override string Name { get; set; } = "Instant Clipwarp";
        public override string ShortcutName { get; set; } = "instant_clipwarp";

        public InstantClipwarp(Mem _mem)
        {
            mem = _mem;
        }

        public override void Start()
        {
            if (!CheatManager.IsHooked || mem == null) return;

            mem.WriteMemory(MemoryAddresses.bilboStateTimer, "float", "10");
            int offset = mem.ReadInt(MemoryAddresses.bilboCoordsY) + 5;
            mem.WriteMemory(MemoryAddresses.bilboCoordsY, "float", offset.ToString());
            mem.WriteMemory(MemoryAddresses.bilboNewCoordsY, "float", "100000");
        }
    }
}
