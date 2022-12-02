import discord
intents = discord.Intents.all()
intents.messages = True
client = discord.Client(intents=intents)
intents.members = True
import unittest

class TestBot(unittest.TestCase):
    async def test_ping(self):
        channel = client.get_channel("1047969552782348352")
        await channel.send("ping?")
        #def check(m):
        #    return m.content == "pong" and m.channel == channel
        res = False#await client.wait_for("message", check=check)
        self.assertTrue(res)
        print(res)
        

@client.event
async def on_ready():
    print("Ready")




ID = "MTA0ODA2MjA4NDg1Mzc5MjgxOA.Gn8A-s.nNeFRthkTkRegI82wEfXn9-UWYZGZSQGcqrQu0"
client.run(ID)
if __name__ == '__main__':
    print("test")
    unittest.main()