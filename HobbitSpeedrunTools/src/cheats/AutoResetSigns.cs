﻿using Memory;

namespace HobbitSpeedrunTools
{
    public class AutoResetSigns : ToggleCheat
    {
        public override CHEAT_ID ID { get; set; } = CHEAT_ID.AUTO_RESET_SIGNS;
        public override string ShortName { get; set; } = "AUTO";
        public override string ShortcutName { get; set; } = "automatically_reset_signs";

        public AutoResetSigns(Mem _mem)
        {
            mem = _mem;
        }

        public override void OnTick()
        {
            if (mem == null) return;

            // Reset the signs if the player loads or dies
            if (mem.ReadInt(MemoryAddresses.loading) == 1 || mem.ReadFloat(MemoryAddresses.health) <= 0)
            {
                mem.WriteMemory(MemoryAddresses.sign1, "int", "1");
                mem.WriteMemory(MemoryAddresses.sign2, "int", "0");
                mem.WriteMemory(MemoryAddresses.sign3, "int", "0");
                mem.WriteMemory(MemoryAddresses.sign4, "int", "1");
                mem.WriteMemory(MemoryAddresses.sign5, "int", "0");
            }
        }
    }
}
