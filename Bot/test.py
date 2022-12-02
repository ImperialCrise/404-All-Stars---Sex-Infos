import discord
intents = discord.Intents.all()
intents.messages = True
client = discord.Client(intents=intents)
intents.members = True
import time


async def test_ping():
    channel = client.get_channel(1047969552782348352)
    await channel.send("ping?")
    res = await client.wait_for("message")
    c = "OK" if res.content == "pong" else "FAILED"
    c = "Ping test: "+c
    print(c)

async def test_help():
    channel = client.get_channel(1047969552782348352)
    await channel.send("!help")
    res = await client.wait_for("message")
    response = "Essaie les commandes suivantes:\n"
    response += "   -> **!help** , pour obtenir l'ensemble des commandes disponibles."
    c = "OK" if res.content == response else "FAILED"
    c = "Help test: "+c
    print(c)

async def test_question_channel():
    channel = client.get_channel(1047969552782348352)
    await channel.send("soigner vih")
    res = await client.wait_for("message")
    c = "OK" if res.content == "Regarde tes DM pour avoir plus d'informations :relaxed:" else "FAILED"
    c = "Question channel test: "+c
    print(c)

        


@client.event
async def on_ready():
    print("--- Waiting for trying the bot ---\n")
    print("Running 3 tests\n")
    await test_ping()
    time.sleep(1.5)
    await test_help()
    time.sleep(1.5)
    await(test_question_channel())
    time.sleep(0)
    await client.close()
    



ID = "MTA0ODA2MjA4NDg1Mzc5MjgxOA.GnqtzM.ROAuk--6LX8kdhKN9pLMLQBMxHLRi3umJcuwfE"

client.run(ID)