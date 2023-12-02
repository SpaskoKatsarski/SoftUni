namespace RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Arena : IArena
    {
        private Dictionary<int, BattleCard> battleCards;

        public int Count => this.battleCards.Count;

        public void Add(BattleCard card)
        {
            this.battleCards.Add(card.Id, card);
        }

        public void ChangeCardType(int id, CardType type)
        {
            if (!this.battleCards.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            this.battleCards[id].Type = type;
        }

        public bool Contains(BattleCard card)
        {
            return this.battleCards.ContainsKey(card.Id);
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            IEnumerable<BattleCard> cards = this.battleCards
                .Values
                .OrderBy(c => c.Swag)
                .ThenBy(c => c.Id);

            if (cards.Count() > n)
            {
                throw new InvalidOperationException();
            }

            return cards.Take(n);
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            return this.battleCards
                .Values
                .Where(c => c.Swag >= lo && c.Swag <= hi)
                .OrderByDescending(c => c.Swag);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            IEnumerable<BattleCard> cards = this.battleCards
                .Values
                .Where(c => c.Type == type);

            if (cards.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return cards
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id);
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            IEnumerable<BattleCard> cards = this.battleCards
                .Values
                .Where(c => c.Type == type && c.Damage <= damage);

            if (cards.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return cards
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id);
        }

        public BattleCard GetById(int id)
        {
            if (!this.battleCards.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            return this.battleCards[id];
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            IEnumerable<BattleCard> cards = this.battleCards
                .Values
                .Where(c => c.Name == name && c.Swag >= lo && c.Swag < hi);

            if (cards.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return cards
                .OrderByDescending(c => c.Swag)
                .ThenBy(c => c.Id);
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            IEnumerable<BattleCard> cards = this.battleCards
                .Values
                .Where(c => c.Name == name);

            if (cards.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return cards
                .OrderByDescending(c => c.Swag)
                .ThenBy(c => c.Id);
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            IEnumerable<BattleCard> cards = this.battleCards
                .Values
                .Where(c => c.Type == type && c.Damage >= lo && c.Damage <= hi);
                
            if (cards.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return cards
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id);
        }

        public IEnumerator<BattleCard> GetEnumerator()
        {
            foreach (var battleCard in this.battleCards.Values)
            {
                yield return battleCard;
            }
        }

        public void RemoveById(int id)
        {
            if (!this.battleCards.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            this.battleCards.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}