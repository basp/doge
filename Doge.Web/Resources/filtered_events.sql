SELECT *
FROM [doge].[recent_events](DEFAULT, DEFAULT, DEFAULT)
WHERE 1 = 1
{% for p in predicates -%}
AND {{ p.xexp }}
{% endfor -%}
ORDER BY [logged_at] DESC