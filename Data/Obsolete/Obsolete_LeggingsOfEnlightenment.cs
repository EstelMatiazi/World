using System;
using Server.Items;

namespace Server.Items
{
    public class LeggingsOfEnlightenment : LeatherLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseFireResistance{ get{ return 9; } }
		public override int BasePoisonResistance{ get{ return 12; } }
		public override int BasePhysicalResistance{ get{ return 11; } }
		public override int BaseEnergyResistance{ get{ return 6; } }
		public override int BaseColdResistance{ get{ return 5; } }

		[Constructable]
		public LeggingsOfEnlightenment()
		{
			Name = "Leggings Of Enlightenment";
			Hue = 0x487;

			SkillBonuses.SetValues( 0, SkillName.Psychology, 10.0 );

			Attributes.BonusInt = 8;
			Attributes.SpellDamage = 10;
			Attributes.LowerManaCost = 10;
			Attributes.LowerRegCost = 5;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public LeggingsOfEnlightenment( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 );
		}

		private void Cleanup( object state ){ Item item = new Artifact_LeggingsOfEnlightenment(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}