using System;
using NUnit.Framework;

namespace Test
{
    class DummyTests
    {

        private Dummy dummy;

        [Test]
        public void TestInit()
        {
            this.dummy = new Dummy(10, 10);
        }

        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);

            Assert.That(dummy.Health, Is.EqualTo(0));
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(0, 10);
            
            Assert.That(() => dummy.TakeAttack(10), Throws.InvalidOperationException);
        }

        [Test]
        public void DeadDummyCanGiveXp()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.That(dummy.GiveExperience(), Is.EqualTo(10));
        }

        [Test]
        public void AliveDummyCantGiveXp()
        {
            Dummy dummy = new Dummy(10, 10);
            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException);
        }
    }
}
