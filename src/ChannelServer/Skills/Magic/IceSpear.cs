// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Aura.Channel.Network.Sending;
using Aura.Channel.Skills.Base;
using Aura.Channel.Skills.Combat;
using Aura.Channel.World.Entities;
using Aura.Mabi.Const;
using Aura.Shared.Network;
using Aura.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Channel.Skills.Magic
{
    /// <summary>
    /// Icespear skill handler
    /// </summary>
    /// <remarks>
    /// Var1: Min damage
    /// Var2: Max damage
    /// Var3: ?
    /// Var4: Explosion Range
    /// Var5: Attack Radius
    /// </remarks>
    [Skill(SkillId.IceSpear)]
    public class IceSpear : IntMagic
    {
        /// <summary>
        /// ID of the skill, used in training.
        /// </summary>
        protected override SkillId SkillId { get { return SkillId.IceSpear; } }

        /// <summary>
        /// String used in effect packets.
        /// </summary>
        protected override string EffectSkillName { get { return "icespear"; } }

        /// <summary>
        /// Weapon tag that's looked for in range calculation.
        /// </summary>
        protected override string SpecialWandTag { get { return "ice_wand"; } }

        /// <summary>
        /// Stri
        /// </summary>

        /// <summary>
		/// Actions to be done before the combat action pack is handled.
		/// </summary>
		/// <param name="attacker"></param>
		/// <param name="skill"></param>
        protected override void BeforeHandlingPack(Creature attacker, Skill skill)
        {
            skill.Stacks = 0;
        }

        /// <summary>
        /// Returns damage for attacker using skill.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="skill"></param>
        /// <returns></returns>
        protected override float GetDamage(Creature attacker, Skill skill)
        {
            var damage = attacker.GetRndMagicDamage(skill, skill.RankData.Var1, skill.RankData.Var2);

            return damage;

        }

        /// <summary>
        /// Return damage radius of the caster using skill.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="skill"></param>
        /// <returns></returns>
        protected object EffectExplosionRange(AttackerAction attacker, Skill skill)
        {
            var range = attacker.EffectExplosionRange(skill, skill.RankData.Var4);

            return range;
        }
        /// <summary>
        /// Units the enemy is knocked back.
        /// </summary>
        private const int KnockbackDistance = 450;
        }
}
