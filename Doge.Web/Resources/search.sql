SELECT TOP 50 *
FROM [doge].[events]
WHERE 1 = 1
{% for t in tags -%}
AND [data].exist('/event/tags/tag[text() = "{{t}}"]') = 1
{% endfor -%}
ORDER BY [logged_at] DESC