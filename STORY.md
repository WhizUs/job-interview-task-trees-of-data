# The Story

## WhizDB Solutions Inc.

For Bob, it was just another day at the office - fixing a broken production database by restoring it from a backup, expanding the storage so that countless amounts of data, which nobody would probably ever use, could fit onto it. He thought that not even the fifth cup of coffee would keep him from falling asleep when Alice from the development department showed up.

> *Alice:* Hey Bob! I hope I'm not interrupting anything, you look pretty busy :). Will you have some free time today? We've got a really weird case...

> *Bob:* Hey Alice! Of course, I would say routine work isn't going anywhere, let's take a look at it right now. What's going on with you guys exactly?

> *Alice:* Well, let me start carefully :). We have this project where we have to store a lot of hierarchies, something like "country management" but with many teams managing it. Oh, and we're using SQL Server...

(Bob almost chokes on his coffee)

> *Bob:* Holy cow! I almost choked on my coffee... I'm afraid of what's coming my way...

> *Alice:* xD ... Yeah, I know... So far, we haven't had any problems at all, but since the data import... everything is catastrophically slow... And what's even crazier is that the more data we import, the slower it gets...

> *Bob:* What exactly are you storing there? Could you show me an example SQL statement to look at?[^1]

> *Alice:* Basically, we've built everything according to all the official docs and various internet searches a.s.o.. On the one hand, we have a tree structure of teams, so each team can have exactly one direct parent and N children. These teams, in turn, have a relationship with the individual countries, for example, "Team C" could have the countries "Austria," "Germany," and "Switzerland." However, individual users are added to various teams, so it becomes clear which user has a relationship with which countries through the teams. Because we have the tree structure, we define that a child team inherits the country assignment of its parents, i.e., "Team C" would only have "Switzerland" directly with it, but, for example, "Germany" would be inherited through "Team B," which is its direct parent, and "Austria" through "Team A," which is also its parent, but through "Team B" since it is the parent of "Team B." Sounds logical so far, right?

> *Bob:* Yeah, so far nothing unusual. It sounds more like a graph database to me, but I don't know all the details :).

> *Alice:* Right, we had to implement this inheritance using views since direct assignments to users are not given. For the views, we used a CTE construct, as often recommended.

> *Bob:* Hmmm. CTE sounds like too much recursion to me :). I also have an idea of what it could be. Have you evaluated SQL Server's built-in features, like HierarchyId? But, anyway, let's see what's going on!

---

[^1]: *You can find the example statement in the [NOTES](NOTES.md)*