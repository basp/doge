SELECT TOP({{ count }})
FROM [doge].[events]
WHERE 1 = 1
{% for p in predicates -%}
AND {{ p.xexp }} = 1
{% endfor -%}
ORDER BY [logged_at] DESC