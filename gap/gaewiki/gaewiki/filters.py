# encoding=utf-8

from google.appengine.dist import use_library
use_library('django', '0.96')
from google.appengine.ext.webapp import template

import util


register = template.create_template_register()


@register.filter
def uurlencode(value):
    return util.uurlencode(value)


@register.filter
def pageurl(value):
    return util.pageurl(value)


@register.filter
def labelurl(value):
    return util.get_label_url(value)


@register.filter
def hostname(value):
    host = value.split('/')[2]
    if host.startswith('www.'):
        host = host[4:]
    return host


@register.filter
def nonestr(value):
    if value is None:
        return ''
    return value


@register.filter
def markdown(text):
    return util.parse_markdown(text)


@register.filter
def wikify(text, page_title=None):
    return util.wikify_filter(text, page_name=page_title)


@register.filter
def wikify_page(page):
    return util.wikify_filter(page.body, page_name=page.title)


@register.filter
def cleanup_summary(text):
    return util.cleanup_summary(text)
