using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

/// <summary>
/// Query and parse vehicle information from the Norwegian Vegvesen website.
/// </summary>
public class VehicleInformation {
	/// <summary>
	/// Parse a single table for all th/td pairs of values.
	/// </summary>
	private static void parseTable(string html, IDictionary<string, Dictionary<string, string>> master) {
		var dict = new Dictionary<string, string>();
		var title = "Unknown (" + (new Guid()) + ")";

		var from = html.IndexOf("<span>", StringComparison.InvariantCultureIgnoreCase);
		var to = html.IndexOf("</span>", StringComparison.InvariantCultureIgnoreCase);

		if (from > -1 &&
		    to > -1)
			title = html.Substring(from + 6, to - from - 6);

		from = -1;

		while (true) {
			from = html.IndexOf("<th>", from + 1, StringComparison.InvariantCultureIgnoreCase);

			if (from == -1)
				break;

			to = html.IndexOf("</th>", from + 1, StringComparison.InvariantCultureIgnoreCase);

			if (to == -1)
				break;

			var key = html
				.Substring(from + 4, to - from - 4)
				.Trim();

			from = html.IndexOf("<td>", from + 1, StringComparison.InvariantCultureIgnoreCase);

			if (from == -1)
				break;

			to = html.IndexOf("</td>", from + 1, StringComparison.InvariantCultureIgnoreCase);

			if (to == -1)
				break;

			var value = html
				.Substring(from + 4, to - from - 4)
				.Trim();

			dict.Add(
				key,
				value);
		}

		master.Add(
			title,
			dict);
	}

	/// <summary>
	/// Parse HTML from vegvesen.no and attempt to find values.
	/// </summary>
	public static Dictionary<string, Dictionary<string, string>> Parse(string html) {
		var dict = new Dictionary<string, Dictionary<string, string>>();
		var from = -1;

		while (true) {
			from = html.IndexOf("kjoretoy-table", from + 50, StringComparison.InvariantCultureIgnoreCase);

			if (from == -1)
				break;

			var to = html.IndexOf("</table>", from + 1, StringComparison.InvariantCultureIgnoreCase);

			if (to == -1)
				break;

			parseTable(html.Substring(from, to - from), dict);
		}

		return dict;
	}

	/// <summary>
	/// Query vegvesen.no from car info and attempt to parse it.
	/// </summary>
	public static Dictionary<string, Dictionary<string, string>> Query(string licensePlate) {
		var url = string.Format(
			"http://www.vegvesen.no/kjoretoy/Kjop+og+salg/Kj%C3%B8ret%C3%B8yopplysninger?registreringsnummer={0}",
			licensePlate.Replace(" ", ""));

		var webClient = new WebClient {
			Encoding = Encoding.UTF8
		};

		var html = webClient.DownloadString(url);

		return Parse(html);
	}
}