using System;
using NUnit.Framework;

namespace Test
{
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [Test]
        public void TestInit()
        {
            this.axe = new Axe(10, 10);
            this.dummy = new Dummy(10, 10);
        }

        [Test]
        public void AxeLoosedDurabilityAfterAttack()
        {
            IWeapon axe = new Axe(10, 10);
            ITarget dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesen't change after attack");
        }

        [Test]
        public void AttackWithBrokenWeapon()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException);
        }
    }
}
